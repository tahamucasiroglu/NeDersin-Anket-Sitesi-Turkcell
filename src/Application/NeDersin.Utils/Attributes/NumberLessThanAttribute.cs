using System.ComponentModel.DataAnnotations;

namespace NeDersin.Utils.Attributes
{
    public sealed class NumberLessThanAttribute : ValidationAttribute
    {
        private readonly int _maxValue;
        private readonly string? _variableName;

        public NumberLessThanAttribute(int maxValue, string? variableName)
        {
            _maxValue = maxValue;
            _variableName = variableName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue)
            {
                if (intValue > _maxValue)
                {
                    return new ValidationResult($"Değişken {_variableName} {_maxValue} değerinden küçük olmalı fakat sizinki {value}");
                }
            }
#pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return ValidationResult.Success;
#pragma warning restore CS8603 // Olası null başvuru dönüşü.

        }
    }
}
