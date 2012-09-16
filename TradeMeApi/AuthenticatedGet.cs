using System;
using System.Collections.Generic;
using System.Linq;
using BadgerSoft.TradeMe.Api.Authentication;
using BadgerSoft.TradeMe.Api.Configuration;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using BadgerSoft.TradeMe.Api;
using System.Net;

namespace BadgerSoft.TradeMe.Api
{
    public class AuthenticatedGet<T> : Get<T>
    {
        protected readonly TradeMeToken TrademeToken;

        public AuthenticatedGet(TradeMeToken accessToken)
        {
            TrademeToken = accessToken;
        }

        protected override IConsumerRequest Request(string query)
        {
            string url = Profile.Current.BaseUrl + query;

            if (TrademeToken == null)
            {
                throw new Exception();
            }

            var consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = Profile.Current.AppKeys.ConsumerKey,
                ConsumerSecret = Profile.Current.AppKeys.ConsumerSecret,
                SignatureMethod = SignatureMethod.HmacSha1,
                UseHeaderForOAuthParameters = true
            };

            var consumerSession = new OAuthSession(consumerContext, Profile.Current.RequestTokenUrl + "?scope=" + Profile.Current.AppKeys.ScopeOfRequest, Profile.Current.AuthorizeUrl, Profile.Current.AccessUrl) { AccessToken = TrademeToken };

            return consumerSession
                .Request()
                .Get()
                .ForUri(new Uri(url))
                .SignWithToken(TrademeToken);
        }
    }
}
