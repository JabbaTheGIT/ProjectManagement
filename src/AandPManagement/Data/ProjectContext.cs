using Microsoft.EntityFrameworkCore;
using AandPManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ClientCompany> ClientCompanys { get; set; }
        public DbSet<Training> Trainings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().ToTable("Asset");
            modelBuilder.Entity<Personnel>().ToTable("Personnel");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<ProjectTask>().ToTable("ProjectTask");
            modelBuilder.Entity<ClientCompany>().ToTable("ClientCompany");
            modelBuilder.Entity<Training>().ToTable("Training");
        }

    }
}