using CorporateCurrencyConverterApi.Models;
using CorporateCurrencyConverterBL.Models;
using CorporateCurrencyConverterBL.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace CorporateCurrencyConverterApi.Controllers
{
    /// <summary>
    /// Currency conversion API Controller
    /// </summary>

    public class CurrencyConversionController : ControllerBase
    {
        
        private readonly ILogger<CurrencyConversionController> _logger;
        private readonly ICurrencyConversionService _currencyConversionService;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Inject dependencies using Constructor Injection
        /// </summary>
        public CurrencyConversionController(ILogger<CurrencyConversionController> logger, ICurrencyConversionService currencyConversionService, IConfiguration configuration)
        {
            _logger = logger;
            _currencyConversionService = currencyConversionService;
            _configuration = configuration;
        }

        /// <summary>
        /// Converting currency based on the input given
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CorporateCurrencyConversionApi")]
        public async Task<double> ConvertCurrency([FromForm] CurrencyConversionInputModel inputModel)
        {
            return _currencyConversionService.ConvertToTargetCurrency(CreateApiSettingsModel(), inputModel);
        }

        /// <summary>
        /// Api settings - taken from appsettings.json
        /// </summary>
        /// <returns></returns>
        private ApiSettings CreateApiSettingsModel()
        {

            var settings = new ApiSettings();

            settings.ApiURL = _configuration.GetValue<string>("CurrencyApi:CurrencyApiBaseUrl");
            settings.UserName = _configuration.GetValue<string>("CurrencyApi:UserName");
            settings.Password = _configuration.GetValue<string>("CurrencyApi:Password");

            return settings;
        }
    }
}