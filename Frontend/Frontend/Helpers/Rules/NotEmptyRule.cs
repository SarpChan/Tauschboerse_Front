using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Frontend.Helpers
{
    class NotEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, $"is Null");
            }

            try
            {
                string str = (string)value;
                
                if(str.Length > 0)
                {
                    return ValidationResult.ValidResult;
                }

                return new ValidationResult(false, $"is Empty");
            }
            catch (Exception)
            {
                return new ValidationResult(false,$"Illegal characters  [expected string]");
            }
        }
    }
}
