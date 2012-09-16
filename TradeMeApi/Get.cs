using System;
using BadgerSoft.TradeMe.Api.Configuration;
using BadgerSoft.TradeMe.Api.Helpers;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api
{
    public class Get<T>
    {
        public virtual T Execute(string query)
        {
            var raw = Request(query).ToString();
            return SerializationHelper.Deserialize<T>(raw);
        }

        protected virtual IConsumerRequest Request(string query)
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
            return consumerSession
                .Request()
                .Get()
                .ForUri(new Uri(url));
        }
    }
}