using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class MKBClassifer_and_Multy_Markers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value",
                table: "AnalysisMarkerData");

            migrationBuilder.AddColumn<bool>(
                name: "boolValue",
                table: "AnalysisMarkerData",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "doubleValue",
                table: "AnalysisMarkerData",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stringValue",
                table: "AnalysisMarkerData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dataType",
                table: "AnalysisMarker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orderRank",
                table: "AnalysisMarker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MKBClassifier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    parentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nodeCount = table.Column<int>(type: "int", nullable: false),
                    additionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKBClassifier", x => x.id);
                    table.ForeignKey(
                        name: "FK_MKBClassifier_MKBClassifier_parentId",
                        column: x => x.parentId,
                        principalTable: "MKBClassifier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MKBClassifierPatient",
                columns: table => new
                {
                    MKBClassifiersid = table.Column<int>(type: "int", nullable: false),
                    Patientsid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKBClassifierPatient", x => new { x.MKBClassifiersid, x.Patientsid });
                    table.ForeignKey(
                        name: "FK_MKBClassifierPatient_MKBClassifier_MKBClassifiersid",
                        column: x => x.MKBClassifiersid,
                        principalTable: "MKBClassifier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MKBClassifierPatient_Patient_Patientsid",
                        column: x => x.Patientsid,
                        principalTable: "Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MKBClassifier_parentId",
                table: "MKBClassifier",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_MKBClassifierPatient_Patientsid",
                table: "MKBClassifierPatient",
                column: "Patientsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MKBClassifierPatient");

            migrationBuilder.DropTable(
                name: "MKBClassifier");

            migrationBuilder.DropColumn(
                name: "boolValue",
                table: "AnalysisMarkerData");

            migrationBuilder.DropColumn(
                name: "doubleValue",
                table: "AnalysisMarkerData");

            migrationBuilder.DropColumn(
                name: "stringValue",
                table: "AnalysisMarkerData");

            migrationBuilder.DropColumn(
                name: "dataType",
                table: "AnalysisMarker");

            migrationBuilder.DropColumn(
                name: "orderRank",
                table: "AnalysisMarker");

            migrationBuilder.AddColumn<double>(
                name: "value",
                table: "AnalysisMarkerData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
