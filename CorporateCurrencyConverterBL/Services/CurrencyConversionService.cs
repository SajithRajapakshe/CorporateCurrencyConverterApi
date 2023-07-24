using CorporateCurrencyConverterApi.Models;
using CorporateCurrencyConverterBL.Helpers;
using CorporateCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCurrencyConverterBL.Services
{
    /// <summary>
    /// Currency conversion service
    /// </summary>
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly IRequestHelper _requestHelper;

        public CurrencyConversionService()
        {
            _requestHelper = new RequestHelper();
        }
        public double ConvertToTargetCurrency(ApiSettings settings, CurrencyConversionInputModel model)
        {
            return _requestHelper.Convert(settings.ApiURL, settings.UserName, settings.Password, model.BaseCurrency, model.TargetCurrency, model.InputAmount);
        }
    }
}
