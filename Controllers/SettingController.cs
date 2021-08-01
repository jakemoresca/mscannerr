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
        private readonly IMovieService _movieService;

        public SettingController(IOptionsSnapshot<IntegrationSettings> settingsOptions, 
            ISettingService settingService, IMovieService movieService)
        {
            _settingOptions = settingsOptions;
            _settingService = settingService;
            _movieService = movieService;
        }

        [HttpGet]
        public IntegrationSettings Get()
        {
            return _settingOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IntegrationSettings model)
        {
            model.MovieSettings.BaseUrl = model.MovieSettings.BaseUrl.Trim();

            if (!string.IsNullOrWhiteSpace(model.MovieSettings.BaseUrl) && !model.MovieSettings.BaseUrl.StartsWith("/"))
            {
                return BadRequest(new { Error = "Base urls must start with /" });
            }

            _settingService.Update(model);

            return Ok(new { ok = true });
        }

        [HttpPost("TestMovieSettings")]
        public async Task<IActionResult> TestAsync([FromBody] IntegrationSettings model)
        {
            var result = await _movieService.TestSettings(model.MovieSettings);

            return Ok(new { ok = result });
        }
    }
}