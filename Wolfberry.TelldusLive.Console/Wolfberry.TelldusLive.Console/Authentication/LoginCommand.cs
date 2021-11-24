using System.CommandLine;
using System.CommandLine.Invocation;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;

namespace Wolfberry.TelldusLive.Console.Authentication
{
    public static class LoginCommand
    {
        public static Command Create(IConfigurationManager configurationManager)
        {
            var command = new Command(
                "login",
                "Login to Telldus Live"
                );
            command.AddOption(new Option<string>(
                "--publicKey",
                () => null,
                "Public key"
            ));
            command.AddOption(new Option<string>(
                "--privateKey",
                () => null,
                "Private key"
            ));
            command.AddOption(new Option<string>(
                "--token",
                () => null,
                "Token"
            ));
            command.AddOption(new Option<string>(
                "--tokenSecret",
                () => null,
                "Token secret"
            ));
            command.Handler = CommandHandler.Create<string, string, string, string>(
                async (publicKey, privateKey, token, tokenSecret) =>
                {
                    if (string.IsNullOrEmpty(publicKey) ||
                        string.IsNullOrEmpty(privateKey) ||
                        string.IsNullOrEmpty(token) ||
                        string.IsNullOrEmpty(tokenSecret))
                    {
                        Printer.WriteLine("Check that all options are set (Public Key, Private Key, Token and Token Secret");
                        Printer.WriteLine("Add --help to see available options.");
                        return;
                    }
                    var authConfiguration = new AuthConfiguration
                    {
                        PublicKey = publicKey,
                        PrivateKey = privateKey,
                        Token = token,
                        TokenSecret = tokenSecret
                    };
                    
                    var client = new TelldusLiveClient(
                        authConfiguration.PublicKey,
                        authConfiguration.PrivateKey,
                        authConfiguration.Token,
                        authConfiguration.TokenSecret);

                    var profile = await client.User.GetProfileAsync();
                    
                    Printer.WriteLine($"Logged in as {profile.Firstname} {profile.Lastname}, {profile.Email}");
                    
                    configurationManager.UpdateAuth(authConfiguration);
                });
            return command;
        }
    }
}
