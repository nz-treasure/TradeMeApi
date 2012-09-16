namespace BadgerSoft.TradeMe.Api.Configuration
{
    public class Profile
    {
        public string BaseUrl { get; private set; }
        public string AccessUrl { get; private set; }
        public string RequestTokenUrl { get; private set; }
        public string AuthorizeUrl { get; private set; }
        public AppKeys AppKeys { get; private set; }

        private static readonly Profile ProductionInstance;
        private static readonly Profile SandboxInstance;

        static Profile()
        {
            ProfileEnvironment = ProfileEnvironment.Sandbox;

            ProductionInstance = new Profile
            {
                BaseUrl = "https://api.trademe.co.nz/v1/",
                AccessUrl = "https://secure.trademe.co.nz/Oauth/AccessToken",
                RequestTokenUrl = "https://secure.trademe.co.nz/Oauth/RequestToken",
                AuthorizeUrl = "https://secure.trademe.co.nz/Oauth/Authorize",
                AppKeys = AppKeys.Production
            };

            SandboxInstance = new Profile
            {
                BaseUrl = "https://api.tmsandbox.co.nz/v1/",
                AccessUrl = "https://secure.tmsandbox.co.nz/Oauth/AccessToken",
                RequestTokenUrl = "https://secure.tmsandbox.co.nz/Oauth/RequestToken",
                AuthorizeUrl = "https://secure.tmsandbox.co.nz/Oauth/Authorize",
                AppKeys = AppKeys.Sandbox
            };
        }

        public static Profile Current
        {
            get 
            {
                switch (ProfileEnvironment)
                {
                    case ProfileEnvironment.Production:
                        return Production;
                    default:
                        return Sandbox;
                }
            }
        }

        public static ProfileEnvironment ProfileEnvironment
        {
            get;
            set;
        }

        public static Profile Production
        {
            get
            {
                return ProductionInstance;
            }
        }

        public static Profile Sandbox
        {
            get
            {
                return SandboxInstance;
            }
        }
    }
}
