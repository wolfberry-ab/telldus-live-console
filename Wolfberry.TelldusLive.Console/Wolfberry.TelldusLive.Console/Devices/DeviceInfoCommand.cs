using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Client;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceInfoCommand
    {
        public static Command Create(IAuthConfiguration configuration)
        {
            var command = new Command("info", "Get information of specific device");
            command.AddOption(new Option<string>(
                "--device-id",
                () => null,
                "Device Id"
            ));
            command.AddOption(new Option<string>(
                "--uuid",
                () => null,
                "UUID"
            ));
            command.AddOption(new Option<string>(
                "--supported-methods",
                () => null,
                "Supported methods"
            ));
            command.AddOption(new Option<string>(
                "--extras",
                () => null,
                "Extras"));

            command.Handler = CommandHandler.Create<string, string, string, string>(async (
                deviceId, uuid, supportedMethods, extras) =>
            {
                try
                {
                    var client = ClientFactory.Create(configuration);
                    var repository = client.Devices;

                    var info = await repository.GetDeviceInfoAsync(deviceId, uuid, supportedMethods, extras);
                    Printer.WriteLine($"{JsonConvert.SerializeObject(info, Formatting.Indented)}");
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