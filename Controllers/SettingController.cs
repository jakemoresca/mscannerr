using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using mscanner.Models;
using mscannerr.Services;

namespace mscannerr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IOptionsSnapshot<IntegrationSettings> _settingOptions;
        private readonly ISettingService _settingService;

        public SettingController(IOptionsSnapshot<IntegrationSettings> settingsOptions, ISettingService settingService)
        {
            _settingOptions = settingsOptions;
            _settingService = settingService;
        }

        [HttpGet]
        public IntegrationSettings Get()
        {
            return _settingOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IntegrationSettings model)
        {
            model.BaseUrl = model.BaseUrl.Trim();

            if (!string.IsNullOrWhiteSpace(model.BaseUrl) && !model.BaseUrl.StartsWith("/"))
            {
                return BadRequest(new { Error = "Base urls must start with /" });
            }

            _settingService.Update(model);

            return Ok(new { ok = true });
        }
    }
}