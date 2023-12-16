using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class add_patient_visits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatientVisitsid",
                table: "MKBClassifier",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientVisitsid",
                table: "BioFile",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientVisits",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    passportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seriaPassport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberPassport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    issuedByPassport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datePassport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kodPassport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNILS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfResidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    INN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OMSNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    registrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    previousMelanoma = table.Column<bool>(type: "bit", nullable: false),
                    previousMelanomaInFamily = table.Column<bool>(type: "bit", nullable: false),
                    nevusType = table.Column<int>(type: "int", nullable: false),
                    PresenceOfFreckles = table.Column<bool>(type: "bit", nullable: false),
                    ObligateFormsOfPrecancer = table.Column<bool>(type: "bit", nullable: false),
                    HormonalChanges = table.Column<bool>(type: "bit", nullable: false),
                    burns = table.Column<int>(type: "int", nullable: false),
                    immuneSystemDiseases = table.Column<bool>(type: "bit", nullable: false),
                    ageGroup = table.Column<int>(type: "int", nullable: false),
                    skinType = table.Column<int>(type: "int", nullable: false),
                    eyeType = table.Column<int>(type: "int", nullable: false),
                    hairType = table.Column<int>(type: "int", nullable: false),
                    hormonalChangesNew = table.Column<int>(type: "int", nullable: false),
                    geneticAbnormalitiesInChromosomes = table.Column<int>(type: "int", nullable: false),
                    melanoma = table.Column<int>(type: "int", nullable: false),
                    compoundMelonoma = table.Column<int>(type: "int", nullable: false),
                    parents = table.Column<int>(type: "int", nullable: false),
                    simba = table.Column<int>(type: "int", nullable: false),
                    relatives = table.Column<int>(type: "int", nullable: false),
                    numberOfMoles = table.Column<bool>(type: "bit", nullable: false),
                    nevus = table.Column<int>(type: "int", nullable: false),
                    birthmarks = table.Column<int>(type: "int", nullable: false),
                    uf = table.Column<int>(type: "int", nullable: false),
                    immuneSystem = table.Column<bool>(type: "bit", nullable: false),
                    XerodermaPigmentosum = table.Column<bool>(type: "bit", nullable: false),
                    patientid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVisits", x => x.id);
                    table.ForeignKey(
                        name: "FK_PatientVisits_Patient_patientid",
                        column: x => x.patientid,
                        principalTable: "Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MKBClassifier_PatientVisitsid",
                table: "MKBClassifier",
                column: "PatientVisitsid");

            migrationBuilder.CreateIndex(
                name: "IX_BioFile_PatientVisitsid",
                table: "BioFile",
                column: "PatientVisitsid");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisits_patientid",
                table: "PatientVisits",
                column: "patientid");

            migrationBuilder.AddForeignKey(
                name: "FK_BioFile_PatientVisits_PatientVisitsid",
                table: "BioFile",
                column: "PatientVisitsid",
                principalTable: "PatientVisits",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MKBClassifier_PatientVisits_PatientVisitsid",
                table: "MKBClassifier",
                column: "PatientVisitsid",
                principalTable: "PatientVisits",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BioFile_PatientVisits_PatientVisitsid",
                table: "BioFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MKBClassifier_PatientVisits_PatientVisitsid",
                table: "MKBClassifier");

            migrationBuilder.DropTable(
                name: "PatientVisits");

            migrationBuilder.DropIndex(
                name: "IX_MKBClassifier_PatientVisitsid",
                table: "MKBClassifier");

            migrationBuilder.DropIndex(
                name: "IX_BioFile_PatientVisitsid",
                table: "BioFile");

            migrationBuilder.DropColumn(
                name: "PatientVisitsid",
                table: "MKBClassifier");

            migrationBuilder.DropColumn(
                name: "PatientVisitsid",
                table: "BioFile");
        }
    }
}
