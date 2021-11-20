using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoboxd.Migrations
{
    public partial class Added_List_Path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "AppLists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "AppLists");
        }
    }
}
