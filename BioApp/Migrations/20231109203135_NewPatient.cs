using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class NewPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "XerodermaPigmentosum",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "birthmarks",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "compoundMelonoma",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "geneticAbnormalitiesInChromosomes",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hormonalChangesNew",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "immuneSystem",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "melanoma",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nevus",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "numberOfMoles",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "parents",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "relatives",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "simba",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "uf",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XerodermaPigmentosum",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "birthmarks",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "compoundMelonoma",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "geneticAbnormalitiesInChromosomes",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "hormonalChangesNew",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "immuneSystem",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "melanoma",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "nevus",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "numberOfMoles",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "parents",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "relatives",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "simba",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "Patient");
        }
    }
}
