using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoboxd.Migrations
{
    public partial class Updated_Entities_For_Best_Practices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppListItems");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppListItems");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppListItems");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppListItems");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppLists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppLists");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppLists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppLists");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppItems");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppItems");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppListItems",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppListItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppListItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppListItems",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
