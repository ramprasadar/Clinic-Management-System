using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsAPI.Migrations
{
    public partial class forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "UserSetup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserSetup",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "UserSetup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "UserSetup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityQuestion",
                table: "UserSetup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "UserSetup",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "UserSetup");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserSetup");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "UserSetup");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "UserSetup");

            migrationBuilder.DropColumn(
                name: "SecurityQuestion",
                table: "UserSetup");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserSetup");
        }
    }
}
