using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.View.Validators
{
    class ValidateReorderPoint : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool flag = true;
            if (value == null)
            {
                return new ValidationResult(false, "Reorder Point cannot be empty.");
            }
            else
            {
                flag = int.TryParse((string)value, out int example);
                if (!flag)
                {
                    return new ValidationResult(false, "Reorder Point must be integer number.");
                }
                if (example < 0)
                {
                    return new ValidationResult(false, "Reorder Point must be higher or equal 0.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
