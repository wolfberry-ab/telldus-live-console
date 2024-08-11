using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Client;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;

namespace Wolfberry.TelldusLive.Console.Sensors
{
    public static class SensorHistoryCommand
    {
        public static Command Create(IAuthConfiguration configuration)
        {
            var command = new Command("history", "Get sensor history");
            command.AddOption(new Option<string>(
                "--sensor-id",
                () => null,
                "Sensor Id"
            ));
            command.AddOption(new Option<bool>(
                "--include-key",
                () => true,
                "Include key"));
            command.AddOption(new Option<bool>(
                "--include-unit",
                () => true,
                "Include unit"));
            command.AddOption(new Option<bool>(
                "--human-date",
                () => true,
                "Include human readable date"));
            command.AddOption(new Option<int?>(
                "--from-timestamp",
                () => 0,
                "From timestamp"));
            command.AddOption(new Option<int?>(
                "--to-timestamp",
                () => 0,
                "To timestamp"));

            command.Handler = CommandHandler.Create<string, bool, bool, bool, int?, int?>(async (
                sensorId, includeKey, includeUnit, humanDate, fromTimestamp, toTimestamp) =>
            {
                var client = ClientFactory.Create(configuration);
                var repository = client.Sensors;

                try
                {
                    var info = await repository.GetHistoryAsync(
                        sensorId, includeKey, includeUnit, humanDate, fromTimestamp, toTimestamp);
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