using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AandPManagement.Data;

namespace AandPManagement.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20161129021343_CompanyProjectsCollection")]
    partial class CompanyProjectsCollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AandPManagement.Models.Asset", b =>
                {
                    b.Property<int>("AssetID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AssetAllocated");

                    b.Property<DateTime?>("AssetAnualTestDate");

                    b.Property<DateTime?>("AssetCOCDate");

                    b.Property<string>("AssetConnections");

                    b.Property<string>("AssetDescription")
                        .IsRequired();

                    b.Property<string>("AssetDimensions");

                    b.Property<DateTime?>("AssetLiftDate");

                    b.Property<string>("AssetLocation");

                    b.Property<DateTime?>("AssetMajorTestDate");

                    b.Property<int?>("AssetPressureRating");

                    b.Property<string>("AssetSerialNumber")
                        .IsRequired();

                    b.Property<int?>("AssetWeight");

                    b.Property<string>("COC");

                    b.Property<int?>("ProjectID");

                    b.HasKey("AssetID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("AandPManagement.Models.ClientCompany", b =>
                {
                    b.Property<int>("ClientCompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ClientCompanyID");

                    b.ToTable("ClientCompany");
                });

            modelBuilder.Entity("AandPManagement.Models.Personnel", b =>
                {
                    b.Property<int>("PersonnelID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Position");

                    b.Property<int?>("ProjectID");

                    b.HasKey("PersonnelID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Personnel");
                });

            modelBuilder.Entity("AandPManagement.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientCompanyID");

                    b.Property<string>("ProjectClient")
                        .IsRequired();

                    b.Property<string>("ProjectLocation")
                        .IsRequired();

                    b.Property<string>("ProjectNumber");

                    b.Property<DateTime>("ProjectStartDate");

                    b.Property<string>("ProjectTitle")
                        .IsRequired();

                    b.HasKey("ProjectID");

                    b.HasIndex("ClientCompanyID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("AandPManagement.Models.ProjectTask", b =>
                {
                    b.Property<int>("ProjectTaskID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectID");

                    b.Property<bool>("TaskComplete");

                    b.Property<DateTime?>("TaskCompletedDate");

                    b.Property<string>("TaskDescription")
                        .IsRequired();

                    b.Property<DateTime?>("TaskSetCompletionDate");

                    b.Property<DateTime>("TaskSetDate");

                    b.Property<string>("TaskTitle")
                        .IsRequired();

                    b.HasKey("ProjectTaskID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectTask");
                });

            modelBuilder.Entity("AandPManagement.Models.Asset", b =>
                {
                    b.HasOne("AandPManagement.Models.Project", "Project")
                        .WithMany("Assets")
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("AandPManagement.Models.Personnel", b =>
                {
                    b.HasOne("AandPManagement.Models.Project", "Project")
                        .WithMany("Crew")
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("AandPManagement.Models.Project", b =>
                {
                    b.HasOne("AandPManagement.Models.ClientCompany", "ClientCompany")
                        .WithMany("Projects")
                        .HasForeignKey("ClientCompanyID");
                });

            modelBuilder.Entity("AandPManagement.Models.ProjectTask", b =>
                {
                    b.HasOne("AandPManagement.Models.Project", "Project")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
