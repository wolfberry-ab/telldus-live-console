using System.CommandLine.Invocation;
using Wolfberry.TelldusLive.Console.Authentication;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Console.Devices;
using Wolfberry.TelldusLive.Console.Sensors;

namespace Wolfberry.TelldusLive.Console.RootCommand
{
    public static class TelldusLiveRootCommand
    {
        public static System.CommandLine.RootCommand Create(IConfigurationManager configurationManager)
        {
            var configuration = configurationManager.GetAuthConfiguration();

            var rootCommand = new System.CommandLine.RootCommand
            {
                Description = "Telldus Live Console",
                Handler = CommandHandler.Create<string>(_ =>
                {
                    const string logo = @"
  __      .___.__  .__
_/  |_  __| _/|  | |__|__  __ ____
\   __\/ __ | |  | |  \  \/ // __ \
 |  | / /_/ | |  |_|  |\   /\  ___/
 |__| \____ | |____/__| \_/  \___  >
           \/                    \/
                        by Wolfberry";
                    Printer.WriteLine(logo);
                    Printer.WriteLine(string.Empty);
                    Printer.WriteLine("Type --help to see available options.");
                })
            };

            rootCommand.AddCommand(SensorCommands.Create(configuration));
            rootCommand.AddCommand(LoginCommand.Create(configurationManager));
            rootCommand.AddCommand(LogoutCommand.Create(configurationManager));
            rootCommand.AddCommand(DeviceCommands.Create(configuration));
            return rootCommand;
        }
    }
}
