using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vivastreet_DataAccess.Migrations
{
    public partial class CityForiegnKeyEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Citys_CityId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_CityId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Advertisements");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Citys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citys_AdvertisementId",
                table: "Citys",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_Advertisements_AdvertisementId",
                table: "Citys",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_Advertisements_AdvertisementId",
                table: "Citys");

            migrationBuilder.DropIndex(
                name: "IX_Citys_AdvertisementId",
                table: "Citys");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Citys");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CityId",
                table: "Advertisements",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Citys_CityId",
                table: "Advertisements",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
