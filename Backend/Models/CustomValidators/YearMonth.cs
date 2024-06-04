using System;
using System.ComponentModel.DataAnnotations;

public class YearMonth : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is not string)
        {
            return new ValidationResult("Value must be a string representing year and month (YYYY-MM).");
        }

        string yearMonth = (string)value;

        if (!DateTime.TryParseExact(yearMonth, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out _))
        {
            return new ValidationResult("Value must be in the format YYYY-MM.");
        }

        return ValidationResult.Success;
    }
}