using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoboxd.Migrations
{
    public partial class Added_Path_To_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "AppItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "AppItems");
        }
    }
}
