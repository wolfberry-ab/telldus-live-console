using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Sensors
{
    public static class SensorInfoCommands
    {
        public static Command Create(ISensorRepository repository)
        {
            var command = new Command("info", "Get information of specific sensor");
            command.AddOption(new Option<string>(
                "--sensor-id",
                () => null,
                "Sensor Id"
            ));
            command.AddOption(new Option<bool>(
                "--include-unit",
                () => true,
                "Include unit"));

            command.Handler = CommandHandler.Create<string, bool>(async (
                sensorId, includeUnit) =>
            {
                try
                {
                    var info = await repository.GetSensorInfoAsync(sensorId, includeUnit);
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
