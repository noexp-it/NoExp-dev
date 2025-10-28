using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoExp.Domain.Entities;
using NoExp.Domain.Entities.Abstracts;
using System.Reflection.Emit;
using System.Xml;

namespace NoExp.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        static ApplicationDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<EmployerProfile> EmployerProfiles { get; set; }
        
        public DbSet<JobAd> JobAds { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<Enum>().HaveConversion<string>();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProfile>()
                .HasDiscriminator<string>("ProfileType")
                .HasValue<CandidateProfile>("Candidate")
                .HasValue<EmployerProfile>("Employer");

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(u => u.UserProfile)
                      .WithOne()
                      .HasForeignKey<UserProfile>(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
            });

            builder.Entity<UserProfile>()
                .HasIndex(up => up.UserId)
                .IsUnique();

            builder.Entity<CandidateProfile>()
                .Property(c => c.ExpectedSalary)
                .HasPrecision(18, 2);

            builder.Entity<EmployerProfile>()
                .HasMany(e => e.JobAds)
                .WithOne(e => e.EmployerProfile)
                .HasForeignKey(e => e.EmployerProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<JobAd>()
                .Property(e => e.PublishDate)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        }
    }
}
