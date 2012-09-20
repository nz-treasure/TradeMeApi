using System;
using System.Xml.Linq;
using AmazedSaint.Elastic;
using AmazedSaint.Elastic.Lib;
using BadgerSoft.TradeMe.Api.Configuration;
using BadgerSoft.TradeMe.Api.Helpers;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api
{
    public class Get<T>
    {
        public string LastError { get; private set; }

        public virtual T Execute(string query)
        {
            var raw = Request(query, (x) => LastError = x).ToString();
            return SerializationHelper.Deserialize<T>(raw);
        }

        public virtual dynamic ExecuteElastic(string query)
        {
            var raw = Request(query, (x) => LastError = x).ToString();
            var xElem = SerializationHelper.Deserialize<XElement>(raw);
            return xElem.ToElastic();
        }

        protected virtual IConsumerRequest Request(string query, Action<string> responseBodyAction)
        {
            var url = Profile.Current.BaseUrl + query;

            var consumerContext = new OAuthConsumerContext
                                      {
                                          ConsumerKey = " ",
                                          ConsumerSecret = " ",
                                          SignatureMethod = SignatureMethod.PlainText,
                                          UseHeaderForOAuthParameters = false
                                      };

            var consumerSession = new OAuthSession(consumerContext, Profile.Current.RequestTokenUrl, Profile.Current.AuthorizeUrl, Profile.Current.AccessUrl);
            if (responseBodyAction != null)
                consumerSession.ResponseBodyAction = responseBodyAction;

            return consumerSession
                .Request()
                .Get()
                .ForUri(new Uri(url));
        }
    }
}