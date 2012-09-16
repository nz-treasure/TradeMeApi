using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api.OAuth
{
    public class TradeMeConsumerRequest : ConsumerRequest
    {
        public TradeMeConsumerRequest(IOAuthContext context, IOAuthConsumerContext consumerContext, IToken token)
            : base(context, consumerContext, token)
        {  }

        public long? ContentLength { get; set; }

        public override System.Net.HttpWebRequest ToWebRequest()
        {
            var request = base.ToWebRequest();

            request.ServicePoint.Expect100Continue = false;

            if (request.ContentLength == 0)
                request.ContentLength = ContentLength.GetValueOrDefault();

            request.ContentType = "application/xml";

            return request;
        }
    }
}
