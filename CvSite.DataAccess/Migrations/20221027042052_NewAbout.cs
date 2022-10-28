using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvSite.DataAccess.Migrations
{
    public partial class NewAbout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.CreateTable(
                name: "NewAbouts",
                columns: table => new
                {
                    NewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewAbouts", x => x.NewId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewAbouts");

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }
    }
}
