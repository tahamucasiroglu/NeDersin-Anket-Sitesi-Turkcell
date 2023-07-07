using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeDersin.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Contexts.Configs
{
    public class UserStatusContextConfig : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> entity)
        {
            entity.Property(e => e.Name)
                        .HasMaxLength(50)
                        .IsUnicode(false);
        }
    }
}
