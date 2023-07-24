using CorporateCurrencyConverterBL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCurrencyConverterBL.Models
{
    /// <summary>
    /// Input model for currency conversion paramaters
    /// </summary>
    public class CurrencyConversionInputModel
    {
        [Required]
        public string BaseCurrency { get; set; }

        [Required]
        public string TargetCurrency { get; set; }

        [Required]
        [ValidateInputAmount]
        public double InputAmount { get; set; }
        public double OutputAmount { get; set; }
    }
}
