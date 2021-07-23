using mscanner.Models;

namespace mscannerr.Services
{
    public class SettingService : ISettingService
    {
        public void Update(Settings model)
        {
            SettingsFile.Write(model);
        }
    }
}