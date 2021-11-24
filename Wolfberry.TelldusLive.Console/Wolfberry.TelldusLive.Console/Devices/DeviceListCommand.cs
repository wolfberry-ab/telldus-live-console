using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceListCommand
    {
        public static Command Create(IDeviceRepository repository)
        {
            var command = new Command("list", "List devices");
            command.AddOption(new Option<bool>(
                "--include-ignored",
                () => false,
                "Include ignored devices"
            ));
            command.AddOption(new Option<bool>(
                "--supported-methods",
                () => true,
                "Supported methods"
            ));
            command.AddOption(new Option<bool>(
                "--extras",
                () => false,
                "Extras"));

            command.Handler = CommandHandler.Create<bool, string, string>(async (
                includeIgnored, supportedMethods, extras) =>
            {
                try
                {
                    var sensors =
                        await repository.GetDevicesAsync(includeIgnored, supportedMethods, extras);
                    Printer.WriteLine($"{JsonConvert.SerializeObject(sensors, Formatting.Indented)}");
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