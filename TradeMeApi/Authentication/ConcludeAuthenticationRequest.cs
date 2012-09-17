using System;
using BadgerSoft.TradeMe.Api.Configuration;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api.Authentication
{
    public class ConcludeAuthenticationRequest
    {
        private readonly IAppKeys _appKeys;

        public ConcludeAuthenticationRequest(IAppKeys appKeys)
        {
            _appKeys = appKeys;
        }

        public TradeMeToken AuthenticateWithVerifier(PreliminaryToken preliminaryToken, string oAuthVerifierOrPin)
        {
            if (string.IsNullOrEmpty(oAuthVerifierOrPin))
            {
                throw new Exception();
            }

            oAuthVerifierOrPin = oAuthVerifierOrPin.Trim();

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

            return new TradeMeToken(session.ExchangeRequestTokenForAccessToken(preliminaryToken.Token, oAuthVerifierOrPin));
        }
    }
}