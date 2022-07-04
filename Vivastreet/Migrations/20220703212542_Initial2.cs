using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vivastreet.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conditions_Advertisements_AdvertisementId",
                table: "Conditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Langauges_Advertisements_AdvertisementId",
                table: "Langauges");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Advertisements_AdvertisementId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_selectAges_Advertisements_AdvertisementId",
                table: "selectAges");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOffereds_Advertisements_AdvertisementId",
                table: "ServiceOffereds");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOffereds_AdvertisementId",
                table: "ServiceOffereds");

            migrationBuilder.DropIndex(
                name: "IX_selectAges_AdvertisementId",
                table: "selectAges");

            migrationBuilder.DropIndex(
                name: "IX_Materials_AdvertisementId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Langauges_AdvertisementId",
                table: "Langauges");

            migrationBuilder.DropIndex(
                name: "IX_Conditions_AdvertisementId",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "ServiceOffereds");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "selectAges");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Langauges");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Conditions");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConditionId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_ConditionId",
                table: "Advertisements",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Conditions_ConditionId",
                table: "Advertisements",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Materials_ConditionId",
                table: "Advertisements",
                column: "ConditionId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Conditions_ConditionId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Materials_ConditionId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_ConditionId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Advertisements");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "ServiceOffereds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "selectAges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Langauges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffereds_AdvertisementId",
                table: "ServiceOffereds",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_selectAges_AdvertisementId",
                table: "selectAges",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_AdvertisementId",
                table: "Materials",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Langauges_AdvertisementId",
                table: "Langauges",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_AdvertisementId",
                table: "Conditions",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conditions_Advertisements_AdvertisementId",
                table: "Conditions",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Langauges_Advertisements_AdvertisementId",
                table: "Langauges",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Advertisements_AdvertisementId",
                table: "Materials",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_selectAges_Advertisements_AdvertisementId",
                table: "selectAges",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOffereds_Advertisements_AdvertisementId",
                table: "ServiceOffereds",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
