using System;
using System.CommandLine;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Client;
using Wolfberry.TelldusLive.Console.Configuration;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceTurnOnCommand
    {
        public static Command Create(IAuthConfiguration configuration)
        {
            var callback = new Func<IDeviceRepository, string, Task>(CallRepository);
            var command = new Command("on", "Turn on a device");
            command = DeviceSimpleCommand.Extend(command, configuration, callback);
            return command;
        }

        private static async Task CallRepository(IDeviceRepository repository, string deviceId) {
            var info = await repository.TurnOnAsync(deviceId);
            Printer.WriteLine($"{JsonConvert.SerializeObject(info, Formatting.Indented)}");
        }
    }
}