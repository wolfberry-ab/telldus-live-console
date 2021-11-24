using System.CommandLine;
using System.CommandLine.Invocation;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;

namespace Wolfberry.TelldusLive.Console.Authentication
{
    public static class LogoutCommand
    {
        public static Command Create(IConfigurationManager configurationManager)
        {
            var command = new Command(
                "logout",
                "Logout to Telldus Live (remove any local secrets)"
                )
            {
                Handler = CommandHandler.Create<string>(_ =>
                {
                   
                    var authConfiguration = new AuthConfiguration();
                    configurationManager.UpdateAuth(authConfiguration);
                    
                    Printer.WriteLine("Logged out");
                })
            };

            return command;
        }
    }
}
