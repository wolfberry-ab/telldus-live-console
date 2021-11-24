using System;
using System.CommandLine;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wolfberry.TelldusLive.Console.Console;
using Wolfberry.TelldusLive.Repositories;

namespace Wolfberry.TelldusLive.Console.Devices
{
    public static class DeviceBellCommand
    {
        public static Command Create(IDeviceRepository repository)
        {
            var callback = new Func<IDeviceRepository, string, Task>(CallRepository);
            var command = new Command("bell", "Send bell command (method 4) to a device");
            command = DeviceSimpleCommand.Extend(command, repository, callback);
            return command;
        }

        private static async Task CallRepository(IDeviceRepository repository, string deviceId) {
            var info = await repository.BellAsync(deviceId);
            Printer.WriteLine($"{JsonConvert.SerializeObject(info, Formatting.Indented)}");
        }
    }
}