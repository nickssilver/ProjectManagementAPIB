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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
