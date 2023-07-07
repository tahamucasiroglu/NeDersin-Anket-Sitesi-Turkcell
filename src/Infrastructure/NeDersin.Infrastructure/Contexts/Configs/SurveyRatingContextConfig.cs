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
    public class SurveyRatingContextConfig : IEntityTypeConfiguration<SurveyRating>
    {
        public void Configure(EntityTypeBuilder<SurveyRating> entity)
        {
            entity.Property(e => e.RatingText).HasColumnType("text");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyRatings)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyRatings_Surveys");

            entity.HasOne(d => d.User).WithMany(p => p.SurveyRatings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_SurveyRatings_Users");
        }
    }
}
