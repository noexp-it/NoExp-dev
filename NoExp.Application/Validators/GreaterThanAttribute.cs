using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public class GreaterThanAttribute(string comparisonProperty) : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var currentValue = (decimal?)value;

        var property = validationContext.ObjectType.GetProperty(comparisonProperty);

        if (property == null)
        {
            return new ValidationResult($"Unknown property: {comparisonProperty}");
        }
            
        var comparisonValue = (decimal?)property.GetValue(validationContext.ObjectInstance);

        if (currentValue.HasValue && comparisonValue.HasValue)
        {
            if (currentValue.Value <= comparisonValue.Value)
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} should be greater than {comparisonProperty}.");
        }

        return ValidationResult.Success;
    }
}
