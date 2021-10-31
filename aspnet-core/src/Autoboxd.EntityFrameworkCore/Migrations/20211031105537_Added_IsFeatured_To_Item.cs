using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoboxd.Migrations
{
    public partial class Added_IsFeatured_To_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppRatings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "AppItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppRatings");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "AppItems");
        }
    }
}
