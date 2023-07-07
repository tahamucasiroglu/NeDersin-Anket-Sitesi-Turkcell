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
    public class QuestionContextConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.Property(e => e.ImageAdress)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            entity.Property(e => e.QuestionText).HasColumnType("text");

            entity.HasOne(d => d.Survey).WithMany(p => p.Questions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Surveys");
        }
    }
}
