using System.CommandLine;
using System.CommandLine.Invocation;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceCommands
    {
        public static Command Create(IAuthConfiguration configuration)
        {
            var command = new Command(
                "devices",
                "Create, read, update and delete devices"
            )
            {
                Handler = CommandHandler.Create<string>(_ =>
                {
                    Printer.WriteLine("No command typed");
                })
            };
            // Add
            command.AddCommand(DeviceBellCommand.Create(configuration));
            command.AddCommand(DeviceCommandCommand.Create(configuration));
            // Dim
            command.AddCommand(DeviceDownCommand.Create(configuration));
            // GetHistory
            command.AddCommand(DeviceInfoCommand.Create(configuration));
            command.AddCommand(DeviceLearnCommand.Create(configuration));
            command.AddCommand(DeviceRemoveCommand.Create(configuration));
            // SetRgb
            // Ignore
            // SetName
            // SetModel
            // SetMetadata
            // SetProtocol
            // SetParameter
            command.AddCommand(DeviceStopCommand.Create(configuration));
            // SetThermostat
            command.AddCommand(DeviceTurnOnCommand.Create(configuration));
            command.AddCommand(DeviceTurnOffCommand.Create(configuration));
            command.AddCommand(DeviceUpCommand.Create(configuration));
            command.AddCommand(DeviceListCommand.Create(configuration));
            return command;
        }
    }
}