using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vivastreet_DataAccess.Migrations
{
    public partial class SecondPhase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_Advertisements_AdvertisementId",
                table: "Citys");

            migrationBuilder.RenameColumn(
                name: "AdvertisementId",
                table: "Citys",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Citys_AdvertisementId",
                table: "Citys",
                newName: "IX_Citys_CityId");

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Rates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RateId",
                table: "Rates",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_Advertisements_CityId",
                table: "Citys",
                column: "CityId",
                principalTable: "Advertisements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Advertisements_RateId",
                table: "Rates",
                column: "RateId",
                principalTable: "Advertisements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_Advertisements_CityId",
                table: "Citys");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Advertisements_RateId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_RateId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Advertisements");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Citys",
                newName: "AdvertisementId");

            migrationBuilder.RenameIndex(
                name: "IX_Citys_CityId",
                table: "Citys",
                newName: "IX_Citys_AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_Advertisements_AdvertisementId",
                table: "Citys",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id");
        }
    }
}
