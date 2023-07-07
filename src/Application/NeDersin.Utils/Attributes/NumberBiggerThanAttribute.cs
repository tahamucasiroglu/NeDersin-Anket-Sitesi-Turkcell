using System.ComponentModel.DataAnnotations;

namespace NeDersin.Utils.Attributes
{
    public sealed class NumberBiggerThanAttribute : ValidationAttribute
    {
        private readonly int _minValue;
        private readonly string? _variableName;

        public NumberBiggerThanAttribute(int minValue, string? variableName = null)
        {
            _minValue = minValue;
            _variableName = variableName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue)
            {
                if (intValue < _minValue)
                {
                    return new ValidationResult($"Değişken {_variableName} {_minValue} değerinden büyük olmalı fakat sizin değeriniz {intValue}");
                }
            }
#pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return ValidationResult.Success;
#pragma warning restore CS8603 // Olası null başvuru dönüşü.
        }
    }
}
