using Microsoft.EntityFrameworkCore.Migrations;

namespace GIFTed.Migrations
{
    public partial class ChangedNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gift");

            migrationBuilder.AddColumn<string>(
                name: "GiftName",
                table: "Gift",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiftName",
                table: "Gift");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gift",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
