using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Get
{
    public sealed class GetUserResponseDTO : IResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public int UserStatusId { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public int Country { get; set; }
        public bool Gender { get; set; }
    }
}
