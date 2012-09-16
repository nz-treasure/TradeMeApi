using System;
using System.Text;
using BadgerSoft.TradeMe.Api.Authentication;
using BadgerSoft.TradeMe.Api.Configuration;
using BadgerSoft.TradeMe.Api.Helpers;
using BadgerSoft.TradeMe.Api.OAuth;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api
{
    public class AuthenticatedPostWithPayload<TIn, TOut>
    {
        protected readonly TradeMeToken TrademeToken;

        public AuthenticatedPostWithPayload(TradeMeToken accessToken)
        {
            TrademeToken = accessToken;
        }

        public virtual TOut Execute(TIn payload, string query)
        {
            var raw = Request(payload, query).ToString();
            return SerializationHelper.Deserialize<TOut>(raw);
        }

        protected virtual IConsumerRequest Request(TIn payload, string query)
        {
            string url = Profile.Current.BaseUrl + query;

            if (TrademeToken == null)
            {
                throw new Exception();
            }

            var serialized = SerializationHelper.Serialize(payload);

            var consumerContext = new OAuthConsumerContext
                                                       {
                                                           ConsumerKey = Profile.Current.AppKeys.ConsumerKey,
                                                           ConsumerSecret = Profile.Current.AppKeys.ConsumerSecret,
                                                           SignatureMethod = SignatureMethod.HmacSha1,
                                                           UseHeaderForOAuthParameters = true
                                                       };

            var consumerSession = new TradeMeOAuthSession(consumerContext, Profile.Current.RequestTokenUrl + "?scope=" + Profile.Current.AppKeys.ScopeOfRequest, Profile.Current.AuthorizeUrl, Profile.Current.AccessUrl) { AccessToken = TrademeToken };

            return consumerSession
                .Request()
                .Post()
                .WithRawContent(Encoding.UTF8.GetBytes(serialized))
                .ForUri(new Uri(url))
                .SignWithToken(TrademeToken);
        }
    }
}