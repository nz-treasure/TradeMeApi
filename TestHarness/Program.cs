using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using BadgerSoft.TradeMe.Api;
using BadgerSoft.TradeMe.Api.Authentication;
using BadgerSoft.TradeMe.Api.Configuration;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Profile.ProfileEnvironment = ProfileEnvironment.Sandbox;

            //var authenticator = new BeginAuthenticationRequest(appKeys);

            const string tokenString = "33314DD004890876B9E8F97745ACFFBA64||||||0AFE893868A6DEA5AA7C128E206D069753||5207682DC7DD7986E8FE54394CBBD1C3F0";
            const string sandboxTokenString = "F6FC088C3BF318C6C4B7F4188483624DE8||||||751DA9629956D8EF1FA084C719D4E6767F||F28CFE8187BC674DDB42617CA4CD4054B7";
            var accessToken = new TradeMeToken(sandboxTokenString);

            //var preliminaryToken = authenticator.GetPin();
            //Process.Start(preliminaryToken.AuthUrl.ToString());

            //var pin = Console.ReadLine();

            //var accessToken = authenticator.AuthenticateWithVerifier(preliminaryToken, pin);

            //Console.Write(accessToken.Serialize());

            //var response = new AuthenticatedPost<WatchListResponse>(appKeys, accessToken).Execute("MyTradeMe/WatchList/509891773.xml");

            var addComment = new ListingAddComment() { comment = "My book is great." };
            var addCommentResponse = new AuthenticatedPostWithPayload<ListingAddComment, Question>(accessToken, AppKeys.Current).Execute(addComment, "Listings/1047708/addcomment.xml");

            //var watchlistRequest = new AuthenticatedGet<Watchlist>(appKeys, accessToken);
            //var watchlist = watchlistRequest.Execute("MyTradeMe/WatchList/All.xml");

            //var singleListingRequest = new Get<ListedItemDetail>();
            //var listing = singleListingRequest.Execute("Listings/509891773.xml");

            //Console.Write(watchlist.ToString());
        }
    }
}
