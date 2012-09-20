using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using AmazedSaint.Elastic.Lib;
using BadgerSoft.TradeMe.Api;
using BadgerSoft.TradeMe.Api.Authentication;
using BadgerSoft.TradeMe.Api.Configuration;

namespace TestHarness
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Profile.ProfileEnvironment = ProfileEnvironment.Production;

    //        var beginAuthenticationRequest = new BeginAuthenticationRequest(AppKeys.Current);
    //        var preliminaryToken = beginAuthenticationRequest.GetPin();

    //        Process.Start(preliminaryToken.AuthUrl.ToString());

    //        var pin = Console.ReadLine();
    //        var concludeAuthenticationRequest = new ConcludeAuthenticationRequest(AppKeys.Current);
    //        var accessToken = concludeAuthenticationRequest.AuthenticateWithVerifier(preliminaryToken, pin);

    //        var watchlist = new AuthenticatedGet<Watchlist>(accessToken, AppKeys.Current).Execute("MyTradeMe/WatchList/All.xml");

    //        Console.Write(watchlist.ToString());
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Profile.ProfileEnvironment = ProfileEnvironment.Production;

            const string tokenString = "57166826D8DF45242FDA95B2680388DCF0||||||9046078462E45A759027C120F3A55EAAF3||F3C83B0CE404F877955003C9609650236C";
            const string sandboxTokenString = "E17DD69CDBE40D1FA9516E8D5F9DECFFE1||||||A2966615C46AA99277FDEA282B84525B23||9E16E7638CDFC10749DFFBA59890924674";
            var accessToken = new TradeMeToken(tokenString);

            dynamic watchlist = new AuthenticatedGet<Watchlist>(accessToken, AppKeys.Current).ExecuteElastic("MyTradeMe/WatchList/All.xml");

            var elements = watchlist.List.Elements as IEnumerable<dynamic>;

            Console.Write((elements.First().ListingId.InternalValue).ToString());
            Console.ReadKey();
        }
    }
}

//const string tokenString = "33314DD004890876B9E8F97745ACFFBA64||||||0AFE893868A6DEA5AA7C128E206D069753||5207682DC7DD7986E8FE54394CBBD1C3F0";
//const string sandboxTokenString = "F6FC088C3BF318C6C4B7F4188483624DE8||||||751DA9629956D8EF1FA084C719D4E6767F||F28CFE8187BC674DDB42617CA4CD4054B7";
//var accessToken = new TradeMeToken(sandboxTokenString);


//var response = new AuthenticatedPost<WatchListResponse>(appKeys, accessToken).Execute("MyTradeMe/WatchList/509891773.xml");

//var addComment = new ListingAddComment() { comment = "My book is great." };
//var addCommentResponse = new AuthenticatedPostWithPayload<ListingAddComment, Question>(accessToken, AppKeys.Current).Execute(addComment, "Listings/1047694/addcomment.xml");

//var singleListingRequest = new Get<ListedItemDetail>();
//var listing = singleListingRequest.Execute("Listings/509891773.xml");