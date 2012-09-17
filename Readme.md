TradeMe API Wrapper for C#
=============

A simple C# wrapper for the trademe.co.nz REST API

Aims
-------
To be a lightweight, easy-to-use wrapper that simplifies the OAuth process and enables straightforward access to all TradeMe REST API functionality.

Install
------
There's a nuget package at https://nuget.org/packages/TradeMeAPIWrapper/1.0.1
```
PM> Install-Package TradeMeAPIWrapper
```

Example
--------
		static void Main(string[] args)
        {
            Profile.ProfileEnvironment = ProfileEnvironment.Sandbox;

            var beginAuthenticationRequest = new BeginAuthenticationRequest(AppKeys.Current);
            var preliminaryToken = beginAuthenticationRequest.GetPin();

            Process.Start(preliminaryToken.AuthUrl.ToString());

            var pin = Console.ReadLine();
            var concludeAuthenticationRequest = new ConcludeAuthenticationRequest(AppKeys.Current);
            var accessToken = concludeAuthenticationRequest.AuthenticateWithVerifier(preliminaryToken, pin);

            var watchlist = new AuthenticatedGet<Watchlist>(accessToken, AppKeys.Current).Execute("MyTradeMe/WatchList/All.xml");

            Console.Write(watchlist.ToString());
        }

Dependencies
-------------
DevDefined OAuth tools (http://code.google.com/p/devdefined-tools/wiki/OAuth) via their nuget package (http://nuget.org/packages/DevDefined.OAuth)

Acknowledgements
---------------
There is a TradeMe-authored sample available at http://code.google.com/p/trade-me-api-wrapper/ which was used as the starting point for this library.  Thanks to the authors of that sample.
I disliked the lack of separation of concerns in the sample, so decided to re-write it.

Contributions
------------
...are welcome

License
-------
[MIT License](http://opensource.org/licenses/mit-license.php)