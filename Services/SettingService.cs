using mscanner.Models;

namespace mscannerr.Services
{
    public class SettingService : ISettingService
    {
        public void Update(IntegrationSettings model)
        {
            SettingsFile.Write(model);
        }
    }
}