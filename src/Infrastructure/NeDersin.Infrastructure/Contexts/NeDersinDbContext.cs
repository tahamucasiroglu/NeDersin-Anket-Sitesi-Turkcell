using Microsoft.EntityFrameworkCore;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Contexts
{
    public partial class NeDersinDbContext : DbContext
    {
        public NeDersinDbContext()
        {
        }

        public NeDersinDbContext(DbContextOptions<NeDersinDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }

        public virtual DbSet<AnswerType> AnswerTypes { get; set; }

        public virtual DbSet<AnswerValue> AnswerValues { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Response> Responses { get; set; }

        public virtual DbSet<Survey> Surveys { get; set; }

        public virtual DbSet<SurveyRating> SurveyRatings { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserStatus> UserStatuses { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=NeDersinDB; Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseTurkishCollection(); 
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //config dosyalarını otomatik olarak alması için

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
