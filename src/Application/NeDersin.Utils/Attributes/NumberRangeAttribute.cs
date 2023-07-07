using System.ComponentModel.DataAnnotations;

namespace NeDersin.Utils.Attributes
{
    public sealed class NumberRangeAttribute : ValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly string? _variableName;

        public NumberRangeAttribute(int minValue, int maxValue, string? variableName)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _variableName = variableName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue)
            {
                if (intValue < _minValue || intValue > _maxValue)
                {
                    return new ValidationResult($"Değişken {_variableName} {_minValue} - {_maxValue} arasında olmalı faakt sizinki {value}");
                }
            }
#pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return ValidationResult.Success;
#pragma warning restore CS8603 // Olası null başvuru dönüşü.
        }
    }
}
