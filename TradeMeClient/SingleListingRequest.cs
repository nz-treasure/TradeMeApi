using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevDefined.OAuth.Framework;
using BadgerSoft.TradeMe.Api;

namespace BadgerSoft.TradeMe.RestClient
{
    public class SingleListingRequest : Request<Listing>
    {
        private const string _query = "Listings/{0}.xml";
        private readonly int _listingId;

        public SingleListingRequest(int listingId)
        {
            _listingId = listingId;
        }

        public override Listing Execute()
        {
            var raw = Query(string.Format(_query, _listingId)).ToString();
            return Deserializer<Listing>.Deserialize(raw);
        }
    }
}
