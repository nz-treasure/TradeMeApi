namespace BadgerSoft.TradeMe.Api.Configuration
{
    public interface IAppKeys
    {
        string ScopeOfRequest { get; }
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
    }
}