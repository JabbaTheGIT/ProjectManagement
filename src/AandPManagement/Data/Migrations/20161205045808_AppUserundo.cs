using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AandPManagement.Data.Migrations
{
    public partial class AppUserundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersRole",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsersName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersRole",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
