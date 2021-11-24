using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Models;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceCommandCommand
    {
        public static Command Create(IDeviceRepository repository)
        {
            var command = new Command("command", "Send command to device");
            command.AddOption(new Option<string>(
                "--device-id",
                () => null,
                "Device Id"
            ));
            command.AddOption(new Option<int>(
                "--method",
                () => 0,
                "Device method (as number, e.g. 128)"
            ));
            command.AddOption(new Option<string>(
                "--value",
                () => null,
                "Command value"));

            command.Handler = CommandHandler.Create<string, int, string>(async (
                deviceId, method, value) =>
            {
                try
                {
                    var methodEnum = (DeviceMethod)Enum.ToObject(typeof(DeviceMethod), method);
                    var sensors =
                        await repository.SendCommandAsync(deviceId, methodEnum, value);
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