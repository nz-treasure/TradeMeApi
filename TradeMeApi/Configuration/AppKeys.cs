namespace BadgerSoft.TradeMe.Api.Configuration
{
    public class AppKeys
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
                ConsumerKey = "33314DD004890876B9E8F97745ACFFBA64",
                ConsumerSecret = "FAE8CC5EAAAF95D811814384BCCD291E22"
            };

            SandboxInstance = new AppKeys
            {
                ScopeOfRequest = "MyTradeMeRead,MyTradeMeWrite,BiddingAndBuying",
                ConsumerKey = "F6FC088C3BF318C6C4B7F4188483624DE8",
                ConsumerSecret = "D33422336F685FF88EC4BB8C45C2BC8ED9"
            };
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
