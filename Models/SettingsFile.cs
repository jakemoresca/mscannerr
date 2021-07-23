using System;
using System.IO;
using System.Text.Json;

namespace mscanner.Models
{
    public static class SettingsFile
    {
        private static object _lock = new object();

        public const string FilePath = "settings.json";

        public static void Write(Settings settings)
        {
            lock (_lock)
            {
                File.WriteAllText(FilePath, JsonSerializer.Serialize(settings));
            }
        }
    }
}