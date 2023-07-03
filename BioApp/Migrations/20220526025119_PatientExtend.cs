using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class PatientExtend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HormonalChanges",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ObligateFormsOfPrecancer",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PresenceOfFreckles",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ageGroup",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "burns",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "immuneSystemDiseases",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "nevusType",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "previousMelanoma",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "previousMelanomaInFamily",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HormonalChanges",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ObligateFormsOfPrecancer",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PresenceOfFreckles",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ageGroup",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "burns",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "immuneSystemDiseases",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "nevusType",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "previousMelanoma",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "previousMelanomaInFamily",
                table: "Patient");
        }
    }
}
