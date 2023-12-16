using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class add_patient_visits_0_1_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientVisits_Patient_patientid",
                table: "PatientVisits");

            migrationBuilder.DropIndex(
                name: "IX_PatientVisits_patientid",
                table: "PatientVisits");

            migrationBuilder.RenameColumn(
                name: "patientid",
                table: "PatientVisits",
                newName: "patientID");

            migrationBuilder.AlterColumn<Guid>(
                name: "patientID",
                table: "PatientVisits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patientID",
                table: "PatientVisits",
                newName: "patientid");

            migrationBuilder.AlterColumn<Guid>(
                name: "patientid",
                table: "PatientVisits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_patientid",
                table: "PatientVisits",
                column: "patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVisits_Patient_patientid",
                table: "PatientVisits",
                column: "patientid",
                principalTable: "Patient",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
