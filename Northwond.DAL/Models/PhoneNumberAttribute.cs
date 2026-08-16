using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Northwind.DAL.Models
{
    /// <summary>
    /// Validates that a phone number only contains digits and phone formatting
    /// characters (spaces, +, -, parentheses, dots). Letters and other symbols
    /// are rejected. Empty values are allowed since phone numbers are optional.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PhoneNumberAttribute : ValidationAttribute, IClientValidatable
    {
        private static readonly Regex PhoneRegex = new Regex(@"^[0-9+\-().\s]+$", RegexOptions.Compiled);

        public PhoneNumberAttribute()
            : base("The {0} field must be a valid phone number (digits, spaces, +, -, parentheses or dots only).")
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

            return PhoneRegex.IsMatch(str);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "phonenumber",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            yield return rule;
        }
    }
}
