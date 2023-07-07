using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class HttpAddressCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string)
            {
                if ((value.ToString() ?? "").Contains("www")) //basit adres kontrolü uyarıdan dolay ?? var oto false verir
                {
                    #pragma warning disable CS8603 // Olası null başvuru dönüşü.
                    return ValidationResult.Success;
                    #pragma warning restore CS8603 // Olası null başvuru dönüşü.
                }
                else
                {
                    return new ValidationResult($"Image Adreste Hatalı");
                }
            }
            #pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return ValidationResult.Success;
            #pragma warning restore CS8603 // Olası null başvuru dönüşü.
        }
    }
}
