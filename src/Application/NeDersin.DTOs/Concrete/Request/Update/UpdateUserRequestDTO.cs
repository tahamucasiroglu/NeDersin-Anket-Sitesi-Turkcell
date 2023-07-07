using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Update
{
    public sealed class UpdateUserRequestDTO : IRequestDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Phone { get; set; }

        public string? IdentityNumber { get; set; }
        public int Country { get; set; }
        public bool Gender { get; set; }

        public int UserStatusId { get; set; }

    }
}
