using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Wolfberry.TelldusLive.Console.Console;

namespace Wolfberry.TelldusLive.Console.Configuration
{
    public static class ConfigUtil
    {
        private const string FileName = "tdlive.json";
        /// <summary>
        /// Home directory, e.g. c:\Users\bob (Windows) or /root (Linux Docker)
        /// </summary>
        private static readonly string ConfigFileFolder = Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile);
        private static readonly string ConfigFile = Path.Combine(ConfigFileFolder, FileName);

        /// <summary>
        /// Write configuration in JSON format
        /// </summary>
        /// <param name="json">Configuration</param>
        public static void WriteConfiguration(string json)
        {
            File.WriteAllText(ConfigFile, json);
            Printer.WriteLine($"saved to {ConfigFile}");
        }

        public static IConfiguration ReadConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(ConfigFileFolder)
                .AddJsonFile(FileName, true)
                .AddEnvironmentVariables()
                .Build();
            return configuration;
        }
    }
}
