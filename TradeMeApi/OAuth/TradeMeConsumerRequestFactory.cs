using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api.OAuth
{
    public class TradeMeConsumerRequestFactory : IConsumerRequestFactory
    {
        public static readonly TradeMeConsumerRequestFactory Instance = new TradeMeConsumerRequestFactory();

        public IConsumerRequest CreateConsumerRequest(IOAuthContext context, IOAuthConsumerContext consumerContext, IToken token)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (consumerContext == null)
            {
                throw new ArgumentNullException("consumerContext");
            }
            return new TradeMeConsumerRequest(context, consumerContext, token);
        }
    }
}
