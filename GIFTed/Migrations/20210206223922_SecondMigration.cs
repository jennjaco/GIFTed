using Microsoft.EntityFrameworkCore.Migrations;

namespace GIFTed.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Receivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Receivers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Receivers");
        }
    }
}
