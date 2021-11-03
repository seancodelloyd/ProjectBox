using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoboxd.Migrations
{
    public partial class Added_List_Entity_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppListItems_AppLists_ItemId",
                table: "AppListItems");

            migrationBuilder.CreateIndex(
                name: "IX_AppListItems_ListId",
                table: "AppListItems",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppListItems_AppLists_ListId",
                table: "AppListItems",
                column: "ListId",
                principalTable: "AppLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppListItems_AppLists_ListId",
                table: "AppListItems");

            migrationBuilder.DropIndex(
                name: "IX_AppListItems_ListId",
                table: "AppListItems");

            migrationBuilder.AddForeignKey(
                name: "FK_AppListItems_AppLists_ItemId",
                table: "AppListItems",
                column: "ItemId",
                principalTable: "AppLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
