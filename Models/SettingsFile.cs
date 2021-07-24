using System;
using System.IO;
using System.Text.Json;

namespace mscanner.Models
{
    public static class SettingsFile
    {
        private static object _lock = new object();

        public const string FilePath = "integrationSettings.json";

        public static void Write(IntegrationSettings settings)
        {
            lock (_lock)
            {
                var integrationSettingsFile = new IntegrationSettingsFile
                {
                    IntegrationSettings = settings
                };

                File.WriteAllText(FilePath, JsonSerializer.Serialize(integrationSettingsFile));
            }
        }
    }

    internal class IntegrationSettingsFile
    {
        public IntegrationSettings IntegrationSettings { get; set; }
    }
}