﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementAPIB.Data;

#nullable disable

namespace ProjectManagementAPIB.Migrations
{
    [DbContext(typeof(ProjectManagementContext))]
    [Migration("20240628133721_Tables")]
    partial class Tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagementAPIB.Models.Budget", b =>
                {
                    b.Property<string>("ProjectID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coordinator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectID");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.County", b =>
                {
                    b.Property<string>("CountyID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountyID");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Donor", b =>
                {
                    b.Property<string>("DonorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorID");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Feedback", b =>
                {
                    b.Property<string>("RespondentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespondentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespondentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RespondentID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.FundingType", b =>
                {
                    b.Property<string>("FundingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FundingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FundingID");

                    b.ToTable("FundingTypes");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Helper", b =>
                {
                    b.Property<string>("HelperID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coordinator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelperName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelperType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HelperID");

                    b.ToTable("Helpers");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.HelperType", b =>
                {
                    b.Property<string>("TypeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("HelperTypes");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Institution", b =>
                {
                    b.Property<string>("InstitutionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AwardLeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountyID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LicenseEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LicenseStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StageID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstitutionID");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.InstitutionStage", b =>
                {
                    b.Property<string>("StageID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StageID");

                    b.ToTable("InstitutionStages");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.InstitutionStatus", b =>
                {
                    b.Property<string>("StatusID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("InstitutionStatuses");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Level", b =>
                {
                    b.Property<string>("LevelID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LevelID");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Participant", b =>
                {
                    b.Property<string>("AdminNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AwardLeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwardLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminNumber");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.PartnerType", b =>
                {
                    b.Property<string>("TypeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("PartnerTypes");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Partnership", b =>
                {
                    b.Property<string>("PartnerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PartnerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartnerID");

                    b.ToTable("Partnerships");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Programm", b =>
                {
                    b.Property<string>("ProgramID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coordinator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramID");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Project", b =>
                {
                    b.Property<string>("ProjectID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coordinator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.ProjectReporting", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ProjectReportings");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.ProjectStatus", b =>
                {
                    b.Property<string>("ProjectStatusID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectStatusID");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Testimonial", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.Training", b =>
                {
                    b.Property<string>("TrainingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coordinator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCounty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainingLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.TrainingCategory", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("TrainingCategories");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.TrainingLevel", b =>
                {
                    b.Property<string>("TrainingLevelID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingLevelID");

                    b.ToTable("TrainingLevels");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.TrainingType", b =>
                {
                    b.Property<string>("TypeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("TrainingTypes");
                });

            modelBuilder.Entity("ProjectManagementAPIB.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
