using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalYearProject.Migrations
{
    public partial class Xray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Xrays",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient = table.Column<int>(type: "int", nullable: false),
                    xrname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    xrimage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    xrcreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xrays", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Xrays");
        }
    }
}
