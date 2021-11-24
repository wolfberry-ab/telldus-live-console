using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Wolfberry.TelldusLive.Console.Configuration
{
    public interface IConfigurationManager
    {
        void UpdateAuth(AuthConfiguration authConfiguration);
        public IAuthConfiguration GetAuthConfiguration();
    }
    
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly ITdLiveConfiguration _tdLiveConfiguration;

        public ConfigurationManager()
        {
            var configuration = ConfigUtil.ReadConfiguration();
            _tdLiveConfiguration = new TdLiveConfiguration();

            var authConfiguration = new AuthConfiguration();
            configuration.GetSection("Auth").Bind(authConfiguration);
            _tdLiveConfiguration.Auth = authConfiguration;
        }
        
        public void UpdateAuth(AuthConfiguration authConfiguration)
        {
            _tdLiveConfiguration.Auth = authConfiguration;
            Save();
        }

        public IAuthConfiguration GetAuthConfiguration()
        {
            return _tdLiveConfiguration.Auth;
        }

        private void Save()
        {
            var json = JsonConvert.SerializeObject(_tdLiveConfiguration, Formatting.Indented);
            ConfigUtil.WriteConfiguration(json);
        }
    }
}