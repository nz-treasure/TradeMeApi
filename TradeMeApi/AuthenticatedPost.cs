using System;
using BadgerSoft.TradeMe.Api.Authentication;
using BadgerSoft.TradeMe.Api.Configuration;
using BadgerSoft.TradeMe.Api.Helpers;
using BadgerSoft.TradeMe.Api.OAuth;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api
{
    public class AuthenticatedPost<T>
    {
        protected readonly TradeMeToken TrademeToken;
        protected readonly IAppKeys AppKeys;

        public AuthenticatedPost(TradeMeToken accessToken, IAppKeys appKeys)
        {
            TrademeToken = accessToken;
            AppKeys = appKeys;
        }

        public virtual T Execute(string query)
        {
            var raw = Request(query).ToString();
            return SerializationHelper.Deserialize<T>(raw);
        }

        protected IConsumerRequest Request(string query)
        {
            string url = Profile.Current.BaseUrl + query;

            if (TrademeToken == null)
            {
                throw new Exception();
            }

            var consumerContext = new OAuthConsumerContext
                                      {
                                          ConsumerKey = AppKeys.ConsumerKey,
                                          ConsumerSecret = AppKeys.ConsumerSecret,
                                          SignatureMethod = SignatureMethod.HmacSha1,
                                          UseHeaderForOAuthParameters = true
                                      };

            var consumerSession = new TradeMeOAuthSession(consumerContext, Profile.Current.RequestTokenUrl + "?scope=" + AppKeys.ScopeOfRequest, Profile.Current.AuthorizeUrl, Profile.Current.AccessUrl) { AccessToken = TrademeToken };

            var consumerRequest = consumerSession
                .Request()
                .Post()
                .ForUri(new Uri(url))
                .SignWithToken(TrademeToken);

            var tradeMeConsumerRequest = consumerRequest as TradeMeConsumerRequest;
            if (tradeMeConsumerRequest != null)
            {
                tradeMeConsumerRequest.ContentLength = 0;
                return tradeMeConsumerRequest;
            }

            return consumerRequest;
        }
    }
}