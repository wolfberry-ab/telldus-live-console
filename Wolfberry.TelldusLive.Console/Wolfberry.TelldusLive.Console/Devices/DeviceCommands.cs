using System.CommandLine;
using System.CommandLine.Invocation;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceCommands
    {
        public static Command Create(IDeviceRepository repository)
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
            command.AddCommand(DeviceBellCommand.Create(repository));
            command.AddCommand(DeviceCommandCommand.Create(repository));
            // Dim
            command.AddCommand(DeviceDownCommand.Create(repository));
            // GetHistory
            command.AddCommand(DeviceInfoCommand.Create(repository));
            command.AddCommand(DeviceLearnCommand.Create(repository));
            command.AddCommand(DeviceRemoveCommand.Create(repository));
            // SetRgb
            // Ignore
            // SetName
            // SetModel
            // SetMetadata
            // SetProtocol
            // SetParameter
            command.AddCommand(DeviceStopCommand.Create(repository));
            // SetThermostat
            command.AddCommand(DeviceTurnOnCommand.Create(repository));
            command.AddCommand(DeviceTurnOffCommand.Create(repository));
            command.AddCommand(DeviceUpCommand.Create(repository));
            command.AddCommand(DeviceListCommand.Create(repository));
            return command;
        }
    }
}