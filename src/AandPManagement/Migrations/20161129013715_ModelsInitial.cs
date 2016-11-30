using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AandPManagement.Migrations
{
    public partial class ModelsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientCompany",
                columns: table => new
                {
                    ClientCompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompany", x => x.ClientCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientCompanyID = table.Column<int>(nullable: true),
                    ProjectClient = table.Column<string>(nullable: false),
                    ProjectLocation = table.Column<string>(nullable: false),
                    ProjectNumber = table.Column<string>(nullable: true),
                    ProjectStartDate = table.Column<DateTime>(nullable: false),
                    ProjectTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Project_ClientCompany_ClientCompanyID",
                        column: x => x.ClientCompanyID,
                        principalTable: "ClientCompany",
                        principalColumn: "ClientCompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetAllocated = table.Column<bool>(nullable: false),
                    AssetAnualTestDate = table.Column<DateTime>(nullable: true),
                    AssetCOCDate = table.Column<DateTime>(nullable: true),
                    AssetConnections = table.Column<string>(nullable: true),
                    AssetDescription = table.Column<string>(nullable: false),
                    AssetDimensions = table.Column<string>(nullable: true),
                    AssetLiftDate = table.Column<DateTime>(nullable: true),
                    AssetLocation = table.Column<string>(nullable: true),
                    AssetMajorTestDate = table.Column<DateTime>(nullable: true),
                    AssetPressureRating = table.Column<int>(nullable: true),
                    AssetSerialNumber = table.Column<string>(nullable: false),
                    AssetWeight = table.Column<int>(nullable: true),
                    COC = table.Column<string>(nullable: true),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetID);
                    table.ForeignKey(
                        name: "FK_Asset_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personnel",
                columns: table => new
                {
                    PersonnelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel", x => x.PersonnelID);
                    table.ForeignKey(
                        name: "FK_Personnel_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    ProjectTaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    TaskComplete = table.Column<bool>(nullable: false),
                    TaskCompletedDate = table.Column<DateTime>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: false),
                    TaskSetCompletionDate = table.Column<DateTime>(nullable: true),
                    TaskSetDate = table.Column<DateTime>(nullable: false),
                    TaskTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.ProjectTaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ProjectID",
                table: "Asset",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_ProjectID",
                table: "Personnel",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientCompanyID",
                table: "Project",
                column: "ClientCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectID",
                table: "ProjectTask",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Personnel");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ClientCompany");
        }
    }
}
