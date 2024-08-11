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
    public static class DeviceLearnCommand
    {
        public static Command Create(IAuthConfiguration configuration)
        {
            var callback = new Func<IDeviceRepository, string, Task>(CallRepository);
            var command = new Command("learn", "Send learn command to device");
            command = DeviceSimpleCommand.Extend(command, configuration, callback);
            return command;
        }

        private static async Task CallRepository(IDeviceRepository repository, string deviceId) {
            var info = await repository.LearnAsync(deviceId);
            Printer.WriteLine($"{JsonConvert.SerializeObject(info, Formatting.Indented)}");
        }
    }
}