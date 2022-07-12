using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vivastreet.Migrations
{
    public partial class ModelsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvertOfTheWeek",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "ClassicAdvert",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "PremierBanner",
                table: "Advertisements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdvertOfTheWeek",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassicAdvert",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PremierBanner",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
