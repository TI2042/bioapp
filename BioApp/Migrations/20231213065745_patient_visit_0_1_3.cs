using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class patient_visit_0_1_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatientVisitsid",
                table: "Patient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientVisitsid",
                table: "Patient",
                column: "PatientVisitsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_PatientVisits_PatientVisitsid",
                table: "Patient",
                column: "PatientVisitsid",
                principalTable: "PatientVisits",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_PatientVisits_PatientVisitsid",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_PatientVisitsid",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PatientVisitsid",
                table: "Patient");
        }
    }
}
