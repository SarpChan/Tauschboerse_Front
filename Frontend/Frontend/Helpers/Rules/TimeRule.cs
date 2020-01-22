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
    class TimeRule : ValidationRule
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
                
                if(str.Length < 1)
                {
                    return new ValidationResult(false, $"is Empty");
                }

                if(Regex.IsMatch(str, "([0-9]|[0-2][0-9]):([0-6][0-9]|[0-9]):([0-6][0-9]|[0-9])"))
                {
                    return ValidationResult.ValidResult;
                }

                return new ValidationResult(false,$"invalid timeformat  [expected string]");
            }
            catch (Exception)
            {
                return new ValidationResult(false,$"Illegal characters  [expected string]");
            }
        }
    }
}
