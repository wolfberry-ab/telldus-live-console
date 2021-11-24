using System;
using System.CommandLine;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceDownCommand
    {
        public static Command Create(IDeviceRepository repository)
        {
            var callback = new Func<IDeviceRepository, string, Task>(CallRepository);
            var command = new Command("down", "Send down command (method 128) to device");
            command = DeviceSimpleCommand.Extend(command, repository, callback);
            return command;
        }

        private static async Task CallRepository(IDeviceRepository repository, string deviceId) {
            var info = await repository.UpAsync(deviceId);
            Printer.WriteLine($"{JsonConvert.SerializeObject(info, Formatting.Indented)}");
        }
    }
}