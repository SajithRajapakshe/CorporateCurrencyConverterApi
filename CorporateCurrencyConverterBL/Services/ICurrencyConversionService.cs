using CorporateCurrencyConverterApi.Models;
using CorporateCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCurrencyConverterBL.Services
{
    /// <summary>
    /// Interface for currency conversion service
    /// </summary>
    public interface ICurrencyConversionService
    {
        double ConvertToTargetCurrency(ApiSettings settings,CurrencyConversionInputModel model);
    }
}
