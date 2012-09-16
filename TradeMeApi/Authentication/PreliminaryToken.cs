using System;
using DevDefined.OAuth.Framework;

namespace BadgerSoft.TradeMe.Api.Authentication
{
    public class PreliminaryToken
    {
        public IToken Token { get; set; }
        public Uri AuthUrl { get; set; }
    }
}
