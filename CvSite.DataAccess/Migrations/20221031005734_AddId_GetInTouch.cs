using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvSite.DataAccess.Migrations
{
    public partial class AddId_GetInTouch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GetInTouches",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetInTouches",
                table: "GetInTouches",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GetInTouches",
                table: "GetInTouches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GetInTouches");
        }
    }
}
