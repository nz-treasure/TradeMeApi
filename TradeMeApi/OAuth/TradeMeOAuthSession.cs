using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevDefined.OAuth.Consumer;

namespace BadgerSoft.TradeMe.Api.OAuth
{
    public class TradeMeOAuthSession : OAuthSession
    {
        public TradeMeOAuthSession(IOAuthConsumerContext consumerContext, string requestTokenUrl, string userAuthorizeUrl, string accessTokenUrl)
            : base(consumerContext, requestTokenUrl, userAuthorizeUrl, accessTokenUrl)
        {
            ConsumerRequestFactory = TradeMeConsumerRequestFactory.Instance;
        }
    }
}
