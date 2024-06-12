using Microsoft.EntityFrameworkCore;
using ProjectManagementAPIB.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProjectManagementAPIB.Data
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : base(options)
        {
        }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<InstitutionStage> InstitutionStages { get; set; }
        public DbSet<InstitutionStatus> InstitutionStatuses { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<ProjectReporting> ProjectReportings { get; set; }
        public DbSet<Program> Programs { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
