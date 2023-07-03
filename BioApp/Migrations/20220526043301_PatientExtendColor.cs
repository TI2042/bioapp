using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class PatientExtendColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "eyeType",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hairType",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "skinType",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eyeType",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "hairType",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "skinType",
                table: "Patient");
        }
    }
}
