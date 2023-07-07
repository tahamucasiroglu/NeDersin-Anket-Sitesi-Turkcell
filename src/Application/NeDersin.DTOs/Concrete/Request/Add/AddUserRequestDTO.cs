using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Add
{
    public sealed class AddUserRequestDTO : IRequestDTO
    {
        [Required(ErrorMessage ="İsim Zorunludur")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "İsim Zorunludur")]
        public string Surname { get; set; } = null!;
        [Required(ErrorMessage = "Mail Zorunludur")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Şifre Zorunludur")]
        public string Password { get; set; } = null!;

        public string? Phone { get; set; }

        public string? IdentityNumber { get; set; }
        [Required(ErrorMessage = "Doğum günü zorunludur")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Yaş Zorunludur")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Şehir Zorunludur")]
        public int Country { get; set; }
        [Required(ErrorMessage = "Cinsiet Zorunludur")]
        public bool Gender { get; set; }
    }
}
