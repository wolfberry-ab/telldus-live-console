using System.CommandLine;
using System.CommandLine.Invocation;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Sensors
{
    public static class SensorCommands
    {
        public static Command Create(ISensorRepository repository)
        {
            var command = new Command(
                "sensors",
                "Create, read, update and delete sensors"
                )
            {
                Handler = CommandHandler.Create<string>(_ =>
                {
                    Printer.WriteLine("No command typed");
                })
            };

            command.AddCommand(SensorListCommand.Create(repository));
            command.AddCommand(SensorInfoCommands.Create(repository));
            command.AddCommand(SensorHistoryCommand.Create(repository));

            return command;
        }
    }
}
