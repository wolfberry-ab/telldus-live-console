using System.CommandLine;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.RootCommand;

namespace Wolfberry.TelldusLive.Console
{
    public static class Program
    {
        private static int Main(string[] args)
        {
            var configurationManager = new ConfigurationManager();
            var rootCommand = TelldusLiveRootCommand.Create(configurationManager);
            return rootCommand.InvokeAsync(args).Result;
        }
    }
}
