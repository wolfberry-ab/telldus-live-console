namespace Wolfberry.TelldusLive.Console.Configuration
{
    public interface ITdLiveConfiguration {
        public IAuthConfiguration Auth { get; set; }
    }

    public class TdLiveConfiguration : ITdLiveConfiguration
    {
        public IAuthConfiguration Auth { get; set; }
    }
}