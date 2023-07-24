using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorporateCurrencyConverterBL.Attributes
{
    /// <summary>
    /// Input validation attribute to check input is a double amount
    /// </summary>
    public class ValidateInputAmount : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return Regex.IsMatch(value.ToString(), "-?\\d+(\\.\\d{1,x})?");
        }
    }
}
