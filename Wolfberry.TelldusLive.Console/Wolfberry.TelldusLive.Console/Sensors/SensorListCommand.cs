using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Client;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;

namespace Wolfberry.TelldusLive.Console.Sensors
{
    public static class SensorListCommand
    {
        public static Command Create(IAuthConfiguration configuration)
        {
            var command = new Command("list", "List sensors");
            command.AddOption(new Option<bool>(
                "--include-ignored",
                () => false,
                "Include ignored sensors"
            ));
            command.AddOption(new Option<bool>(
                "--include-values",
                () => true,
                "Include sensor values"
            ));
            command.AddOption(new Option<bool>(
                "--include-scale",
                () => false,
                "Include scale"));
            command.AddOption(new Option<bool>(
                "--include-unit",
                () => true,
                "Include unit"));

            command.Handler = CommandHandler.Create<bool, bool, bool, bool>(async (
                includeIgnored, includeValues, includeScale, includeUnit) =>
            {
                var client = ClientFactory.Create(configuration);
                var repository = client.Sensors;

                try
                {
                    var sensors =
                        await repository.GetSensorsAsync(includeIgnored, includeValues, includeScale, includeUnit);
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
