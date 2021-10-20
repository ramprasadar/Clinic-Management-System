using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsAPI.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "Patient",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Doctor",
                newName: "ToTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Doctor",
                newName: "FromTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Patient",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "ToTime",
                table: "Doctor",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "FromTime",
                table: "Doctor",
                newName: "EndTime");
        }
    }
}
