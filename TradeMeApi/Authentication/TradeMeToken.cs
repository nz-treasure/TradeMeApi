using System;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api.Authentication
{
    public class TradeMeToken : TokenBase, IToken
    {
        public TradeMeToken(IToken token)
        {
            ConsumerKey = token.ConsumerKey;
            Realm = token.Realm;
            SessionHandle = token.SessionHandle;
            Token = token.Token;
            TokenSecret = token.TokenSecret;
        }

        public TradeMeToken(string serialized)
        {
            Parse(serialized);
        }

        public string Serialize()
        {
            return string.Format("{0}||{1}||{2}||{3}||{4}", ConsumerKey, Realm, SessionHandle, Token, TokenSecret);
        }

        public void Parse(string serialized)
        {
            var segments = serialized.Split(new[] { "||" }, StringSplitOptions.None);
            ConsumerKey = segments[0];
            Realm = segments[1];
            SessionHandle = segments[2];
            Token = segments[3];
            TokenSecret = segments[4];
        }
    }
}
