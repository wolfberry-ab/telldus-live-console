namespace Wolfberry.TelldusLive.Console.Configuration
{
    public interface IAuthConfiguration
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }
    }
    
    public class AuthConfiguration : IAuthConfiguration
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }
    }
}