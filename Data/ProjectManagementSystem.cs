using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Models;

namespace ProjectManagementAPIB.Data
{
    // Represents the database context for the Project Management System API
    public class ProjectManagementContext : DbContext
    {
        // Constructor to pass the options to the base DbContext class
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : base(options)
        {
        }

        // DbSet properties for each entity in the system, representing tables in the database
        public DbSet<AwardCenter> AwardCenters { get; set; }
        public DbSet<AwardCStages> AwardCenterStages { get; set; }
        public DbSet<AwardCStatus> AwardCenterStatus { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<SubCounty> SubCounties { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ParticipantAward> ParticipantAwards { get; set; }
        public DbSet<ParticipantActivity> ParticipantProjects { get; set; }
        public DbSet<ParticipantLevel> ParticipantLevels { get; set; }
        public DbSet<ParticipantStatus> ParticipantStatuses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<ProjectReporting> ProjectReportings { get; set; }
        public DbSet<Programm> Programs { get; set; }
        public DbSet<Helper> Helpers { get; set; }
        public DbSet<HelperType> HelperTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingLevel> TrainingLevels { get; set; }
        public DbSet<TrainingCategory> TrainingCategories { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<FundingType> FundingTypes { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }

        // Configure the model properties and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set the precision and scale for the 'Cost' property in the 'Budget' entity
            modelBuilder.Entity<Budget>()
                .Property(b => b.Cost)
                .HasColumnType("decimal(18,2)");

            // Set the precision and scale for the 'Cost' property in the 'Project' entity
            modelBuilder.Entity<Project>()
                .Property(p => p.Cost)
                .HasColumnType("decimal(18,2)");

            // Set and configure the foreign key relationship
            modelBuilder.Entity<SubCounty>()
                .HasOne(sc => sc.County)
                .WithMany(c => c.SubCounties)
                .HasForeignKey(sc => sc.CountyID);

            // Configure User entity properties
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName("Password");

            // Add further entity configurations here if necessary
        }

        // Override SaveChanges to hash passwords before saving to the database
        public override int SaveChanges()
        {
            // Hash passwords before saving changes
            HashPasswords();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Hash passwords before saving changes
            HashPasswords();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void HashPasswords()
        {
            foreach (var entry in ChangeTracker.Entries<User>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                var user = entry.Entity;
                if (!string.IsNullOrEmpty(user.Password) && !user.Password.StartsWith("$2a$"))
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                }
            }
        }
    }
}
