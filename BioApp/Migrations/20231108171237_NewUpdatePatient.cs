using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class NewUpdatePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBirth",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfResidence",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SNILS",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PlaceOfBirth",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PlaceOfResidence",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "SNILS",
                table: "Patient");
        }
    }
}
