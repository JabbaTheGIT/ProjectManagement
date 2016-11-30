using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AandPManagement.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Project_ProjectID",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_Project_ProjectID",
                table: "Personnel");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Personnel",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Project_ProjectID",
                table: "Asset",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_Project_ProjectID",
                table: "Personnel",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Project_ProjectID",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_Project_ProjectID",
                table: "Personnel");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Personnel",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Asset",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Project_ProjectID",
                table: "Asset",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_Project_ProjectID",
                table: "Personnel",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
