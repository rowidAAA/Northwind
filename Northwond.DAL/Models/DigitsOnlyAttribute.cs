using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Northwind.DAL.Models
{
    /// <summary>
    /// Validates that a value contains only digits (0-9). Letters, spaces and
    /// symbols are rejected. Empty values are allowed since the field is optional.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DigitsOnlyAttribute : ValidationAttribute, IClientValidatable
    {
        private static readonly Regex DigitsRegex = new Regex(@"^[0-9]+$", RegexOptions.Compiled);

        public DigitsOnlyAttribute()
            : base("The {0} field must contain only numbers.")
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var str = value as string;
            if (str == null)
                return true; // non-string types are handled by their own attributes

            if (string.IsNullOrWhiteSpace(str))
                return true; // optional field

            return DigitsRegex.IsMatch(str);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "digitsonly",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            yield return rule;
        }
    }
}
