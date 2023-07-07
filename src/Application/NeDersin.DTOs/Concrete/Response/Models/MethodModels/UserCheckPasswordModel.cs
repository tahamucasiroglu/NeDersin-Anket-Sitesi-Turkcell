using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Models.MethodModels
{
    public sealed class UserCheckPasswordModel
    {
        public int? Id { get; set; }
        public string? Email { get; set; } = null!;
        [Required(ErrorMessage = "Password olmadan nasıl password kontrol edeyim canım benim")]
        public string Password { get; set; } = null!;
    }
}
