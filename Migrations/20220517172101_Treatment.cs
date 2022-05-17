using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalYearProject.Migrations
{
    public partial class Treatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "patient",
                table: "Treatments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "patient",
                table: "Treatments");
        }
    }
}
