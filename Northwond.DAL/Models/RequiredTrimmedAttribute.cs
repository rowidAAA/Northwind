using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Northwind.DAL.Models
{
    /// <summary>
    /// Requires a value that is not null and not whitespace-only. Unlike [Required],
    /// a string made only of spaces fails validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredTrimmedAttribute : ValidationAttribute, IClientValidatable
    {
        public RequiredTrimmedAttribute()
            : base("The {0} field is required.")
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var str = value as string;
            if (str == null)
                return true; // non-string types are handled by their own attributes

            return !string.IsNullOrWhiteSpace(str);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "requiredtrimmed",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            yield return rule;
        }
    }
}
