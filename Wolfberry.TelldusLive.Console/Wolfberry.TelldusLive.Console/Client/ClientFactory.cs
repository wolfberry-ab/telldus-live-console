using Wolfberry.TelldusLive.Console.Configuration;

namespace Wolfberry.TelldusLive.Console.Client
{
    public static class ClientFactory
    {
        public static ITelldusLiveClient Create(IAuthConfiguration configuration)
        {
            var client = new TelldusLiveClient(
            configuration.PublicKey,
            configuration.PrivateKey,
            configuration.Token,
                configuration.TokenSecret);
            return client;
        }
    }
}
