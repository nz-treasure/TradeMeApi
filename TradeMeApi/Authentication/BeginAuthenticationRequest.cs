using System;
using BadgerSoft.TradeMe.Api.Configuration;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api.Authentication
{
    public class BeginAuthenticationRequest
    {
        private readonly IAppKeys _appKeys;

        public BeginAuthenticationRequest(IAppKeys appKeys)
        {
            _appKeys = appKeys;
        }

        public PreliminaryToken GetOAuthVerifier(Uri callback)
        {
            var consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = _appKeys.ConsumerKey,
                ConsumerSecret = _appKeys.ConsumerSecret,
                SignatureMethod = SignatureMethod.HmacSha1,
                UseHeaderForOAuthParameters = true
            };

            var session = new OAuthSession(
                consumerContext,
                Profile.Current.RequestTokenUrl + "?scope=" + _appKeys.ScopeOfRequest,
                Profile.Current.AuthorizeUrl,
                Profile.Current.AccessUrl);

            if (callback != null)
            {
                session.CallbackUri = callback;
            }

            var requestToken = session.GetRequestToken();

            return new PreliminaryToken
            {
                AuthUrl = new Uri(session.GetUserAuthorizationUrlForToken(requestToken)),
                Token = requestToken
            };
        }

        public PreliminaryToken GetPin()
        {
            return GetOAuthVerifier(null);
        }
    }
}
