using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class AnalysisMarkerAndCommonAnalysis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonBloodAnalysis");

            migrationBuilder.CreateTable(
                name: "AnalysisMarker",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    measure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    measureEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analysisType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisMarker", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CommonAnalysis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfBiosampleCollecting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfAnalysis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnalysisIsPerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analysisType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAnalysis", x => x.id);
                    table.ForeignKey(
                        name: "FK_CommonAnalysis_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommonAnalysis_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisMarkerNormValue",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalysisMarkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    minValue = table.Column<double>(type: "float", nullable: false),
                    maxValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisMarkerNormValue", x => x.id);
                    table.ForeignKey(
                        name: "FK_AnalysisMarkerNormValue_AnalysisMarker_AnalysisMarkerId",
                        column: x => x.AnalysisMarkerId,
                        principalTable: "AnalysisMarker",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysisMarkerNormValue_PatientGroup_PatientGroupId",
                        column: x => x.PatientGroupId,
                        principalTable: "PatientGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisMarkerData",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommonAnalysisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalysisMarkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisMarkerData", x => x.id);
                    table.ForeignKey(
                        name: "FK_AnalysisMarkerData_AnalysisMarker_AnalysisMarkerId",
                        column: x => x.AnalysisMarkerId,
                        principalTable: "AnalysisMarker",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysisMarkerData_CommonAnalysis_CommonAnalysisId",
                        column: x => x.CommonAnalysisId,
                        principalTable: "CommonAnalysis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisMarkerData_AnalysisMarkerId",
                table: "AnalysisMarkerData",
                column: "AnalysisMarkerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisMarkerData_CommonAnalysisId",
                table: "AnalysisMarkerData",
                column: "CommonAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisMarkerNormValue_AnalysisMarkerId",
                table: "AnalysisMarkerNormValue",
                column: "AnalysisMarkerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisMarkerNormValue_PatientGroupId",
                table: "AnalysisMarkerNormValue",
                column: "PatientGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonAnalysis_DoctorId",
                table: "CommonAnalysis",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonAnalysis_PatientId",
                table: "CommonAnalysis",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisMarkerData");

            migrationBuilder.DropTable(
                name: "AnalysisMarkerNormValue");

            migrationBuilder.DropTable(
                name: "CommonAnalysis");

            migrationBuilder.DropTable(
                name: "AnalysisMarker");

            migrationBuilder.CreateTable(
                name: "CommonBloodAnalysis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonBloodAnalysis", x => x.id);
                    table.ForeignKey(
                        name: "FK_CommonBloodAnalysis_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonBloodAnalysis_PatientId",
                table: "CommonBloodAnalysis",
                column: "PatientId");
        }
    }
}
