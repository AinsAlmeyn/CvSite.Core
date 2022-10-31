using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvSite.DataAccess.Migrations
{
    public partial class BlogInfo_Content_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BlogInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "BlogInfos");
        }
    }
}
