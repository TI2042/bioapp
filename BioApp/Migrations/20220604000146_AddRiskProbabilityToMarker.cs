using Microsoft.EntityFrameworkCore.Migrations;

namespace BioApp.Migrations
{
    public partial class AddRiskProbabilityToMarker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "probability",
                table: "AnalysisMarker",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "probability",
                table: "AnalysisMarker");
        }
    }
}
