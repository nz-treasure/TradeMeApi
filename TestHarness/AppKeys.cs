using BadgerSoft.TradeMe.Api.Configuration;

namespace TestHarness
{
    public class AppKeys : IAppKeys
    {
        public string ScopeOfRequest { get; private set; }
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }

        private static readonly AppKeys ProductionInstance;
        private static readonly AppKeys SandboxInstance;

        static AppKeys()
        {
            ProductionInstance = new AppKeys
            {
                ScopeOfRequest = "MyTradeMeRead,MyTradeMeWrite,BiddingAndBuying",
                ConsumerKey = "57166826D8DF45242FDA95B2680388DCF0",
                ConsumerSecret = "013C6DE6E0B28F0CFE710033DCEB2D487A"
            };

            SandboxInstance = new AppKeys
            {
                ScopeOfRequest = "MyTradeMeRead,MyTradeMeWrite,BiddingAndBuying",
                ConsumerKey = "E17DD69CDBE40D1FA9516E8D5F9DECFFE1",
                ConsumerSecret = "92F7AC8798B3D065959CD397065C494487"
            };
        }

        public static AppKeys Current
        {
            get
            {
                switch (Profile.ProfileEnvironment)
                {
                    case ProfileEnvironment.Production:
                        return Production;
                    default:
                        return Sandbox;
                }
            }
        }

        public static AppKeys Production
        {
            get
            {
                return ProductionInstance;
            }
        }

        public static AppKeys Sandbox
        {
            get
            {
                return SandboxInstance;
            }
        }
    }
}
