using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AandPManagement.Migrations
{
    public partial class AssetModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AssetMPITestDate",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AssetPreJobCheck",
                table: "Asset",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssetVisualTestDate",
                table: "Asset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetMPITestDate",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssetPreJobCheck",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssetVisualTestDate",
                table: "Asset");
        }
    }
}
