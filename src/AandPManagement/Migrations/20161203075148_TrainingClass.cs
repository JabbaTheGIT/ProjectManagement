using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AandPManagement.Migrations
{
    public partial class TrainingClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    TrainingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfTraining = table.Column<DateTime>(nullable: false),
                    PersonnelID = table.Column<int>(nullable: false),
                    TypeTraining = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.TrainingID);
                    table.ForeignKey(
                        name: "FK_Training_Personnel_PersonnelID",
                        column: x => x.PersonnelID,
                        principalTable: "Personnel",
                        principalColumn: "PersonnelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Training_PersonnelID",
                table: "Training",
                column: "PersonnelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Training");
        }
    }
}
