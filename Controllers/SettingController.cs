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
        private readonly Settings _settings;
        private readonly ISettingService _settingService;

        public SettingController(IOptionsSnapshot<Settings> settingsOptions, ISettingService settingService)
        {
            _settings = settingsOptions.Value;
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_settings);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Settings model)
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