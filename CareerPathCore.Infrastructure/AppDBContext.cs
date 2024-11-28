using CareerPathCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerPathCore.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<UserHardSkill> HardSkills { get; set; }
        public DbSet<JobArea> JobAreas { get; set; }
        public DbSet<JobLevel> JobLevels { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<UserSoftSkill> SoftSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.User)
                .WithOne()
                .HasForeignKey<UserProfile>(up => up.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.EducationLevel)
                .WithMany()
                .HasForeignKey(up => up.EducationLevelId);

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.CurrentJobRole)
                .WithMany()
                .HasForeignKey(up => up.CurrentJobRoleId);

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.FutureJobRole)
                .WithMany()
                .HasForeignKey(up => up.FutureJobRoleId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            SeedEducationLevels(modelBuilder);
            SeedJobRoles(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedJobRoles(ModelBuilder modelBuilder)
        {
            var jobAreas = new List<JobArea>
    {
        new JobArea { Id = Guid.NewGuid(), Name = "Frontend Engineering" },
        new JobArea { Id = Guid.NewGuid(), Name = "Backend Engineering" },
        new JobArea { Id = Guid.NewGuid(), Name = "Fullstack Engineering" },
        new JobArea { Id = Guid.NewGuid(), Name = "Manual Testing" },
        new JobArea { Id = Guid.NewGuid(), Name = "Automation Testing" },
        new JobArea { Id = Guid.NewGuid(), Name = "DevOps/SRE/Infra" },
        new JobArea { Id = Guid.NewGuid(), Name = "UX/UI Design" },
        new JobArea { Id = Guid.NewGuid(), Name = "Data Engineering" },
        new JobArea { Id = Guid.NewGuid(), Name = "Data Science" },
        new JobArea { Id = Guid.NewGuid(), Name = "AI Engineering" },
        new JobArea { Id = Guid.NewGuid(), Name = "Mobile Engineering" }
    };

            var jobLevels = new List<JobLevel>
    {
        new JobLevel { Id = Guid.NewGuid(), Name = "Junior" },
        new JobLevel { Id = Guid.NewGuid(), Name = "Mid" },
        new JobLevel { Id = Guid.NewGuid(), Name = "Senior" },
        new JobLevel { Id = Guid.NewGuid(), Name = "Lead" },
        new JobLevel { Id = Guid.NewGuid(), Name = "Architect" }
    };

            // Seed job areas and job levels first
            modelBuilder.Entity<JobArea>().HasData(jobAreas);
            modelBuilder.Entity<JobLevel>().HasData(jobLevels);

            // Now seed job roles with only the foreign key values
            var jobRoles = new List<JobRole>();

            foreach (var jobArea in jobAreas)
            {
                foreach (var jobLevel in jobLevels)
                {
                    jobRoles.Add(new JobRole
                    {
                        Id = Guid.NewGuid(),
                        JobAreaId = jobArea.Id,  // Use the foreign key
                        JobLevelId = jobLevel.Id // Use the foreign key
                    });
                }
            }

            modelBuilder.Entity<JobRole>().HasData(jobRoles);
        }

        private void SeedEducationLevels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationLevel>().HasData(
                new EducationLevel
                {
                    Id = Guid.NewGuid(),
                    Name = "No Formal Education"
                },
                new EducationLevel
                {
                    Id = Guid.NewGuid(),
                    Name = "High School Diploma or Equivalent"
                },
                new EducationLevel
                {
                    Id = Guid.NewGuid(),
                    Name = "Associate's Degree"
                },
                new EducationLevel
                {
                    Id = Guid.NewGuid(),
                    Name = "Bachelor's Degree"
                },
                new EducationLevel
                {
                    Id = Guid.NewGuid(),
                    Name = "Master's Degree"
                },
                new EducationLevel
                {
                    Id = Guid.NewGuid(),
                    Name = "Doctorate (Ph.D.)"
                },
                new EducationLevel
                {
                    Id = Guid.NewGuid(),
                    Name = "Professional Certification"
                }
            );
        }
    }
}
