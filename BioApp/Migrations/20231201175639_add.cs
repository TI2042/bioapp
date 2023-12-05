using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datePassport",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "issuedByPassport",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kodPassport",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numberPassport",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "seriaPassport",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datePassport",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "issuedByPassport",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "kodPassport",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "numberPassport",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "seriaPassport",
                table: "Patient");
        }
    }
}
