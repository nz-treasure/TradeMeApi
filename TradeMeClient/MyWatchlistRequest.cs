using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevDefined.OAuth.Framework;
using BadgerSoft.TradeMe.Api;

namespace BadgerSoft.TradeMe.RestClient
{
    public class MyWatchlistRequest : AuthenticatedRequest<Watchlist>
    {
        private const string _query = "MyTradeMe/WatchList/All.xml";

        public MyWatchlistRequest(AppKeys appKeys, TradeMeToken tradeMeToken)
            : base(appKeys, tradeMeToken)
        { }

        public override Watchlist Execute()
        {
            var raw = Query(_query).ToString();
            return Deserializer<Watchlist>.Deserialize(raw);
        }
    }
}
