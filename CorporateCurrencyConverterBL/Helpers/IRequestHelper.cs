using CorporateCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCurrencyConverterBL.Helpers
{
    /// <summary>
    /// Generic interface for API request operations
    /// </summary>
    public interface IRequestHelper
    {
        double Convert(string ApiBaseUrl, string userName, string password, string baseCurrency, string targetCurrency, double inputAmount);
    }
}
