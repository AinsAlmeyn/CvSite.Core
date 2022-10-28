using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvSite.DataAccess.Migrations
{
    public partial class Default_Changes_Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Abouts");
        }
    }
}
