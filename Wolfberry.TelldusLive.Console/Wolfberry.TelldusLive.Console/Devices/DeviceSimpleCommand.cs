using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Wolfberry.TelldusLive.Console.Client;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceSimpleCommand
    {
        public static Command Extend(Command command, IAuthConfiguration configuration,
            Func<IDeviceRepository, string, Task> callback)
        {
            command.AddOption(new Option<string>(
                "--device-id",
                () => null,
                "Device Id"
            ));
            
            command.Handler = CommandHandler.Create<string>(async deviceId =>
            {
                var client = ClientFactory.Create(configuration);
                var repository = client.Devices;
                try
                {
                    await callback(repository, deviceId);
                }
                catch (Exception e)
                {
                    Printer.WriteLine($"Command failed: {e.Message}");
                    return ExitCode.Error;
                }

                return ExitCode.Success;
            });

            return command;
        }
    }
}