using System.ComponentModel.DataAnnotations;

namespace NeDersin.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class GuidValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value is not Guid)
            {
                return new ValidationResult($"Address Tipi Yanlış veya Boş");
            }
            #pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return ValidationResult.Success;
            #pragma warning restore CS8603 // Olası null başvuru dönüşü.
        }
    }
}
