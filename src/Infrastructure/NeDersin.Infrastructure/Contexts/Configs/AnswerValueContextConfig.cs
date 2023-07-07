using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeDersin.Entities.Concrete.Entities;

namespace NeDersin.Infrastructure.Contexts.Configs
{
    public class AnswerValueContextConfig : IEntityTypeConfiguration<AnswerValue>
    {
        public void Configure(EntityTypeBuilder<AnswerValue> entity)
        {
            entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            entity.Property(e => e.Value).HasColumnType("text");
        }
    }
}
