using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.View.Validators
{
    class ValidateProductName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string v = (string)value;
            if (v.Length == 0)
                return new ValidationResult(false, "Product name cannot be empty.");
            return ValidationResult.ValidResult;
        }
    }
}
