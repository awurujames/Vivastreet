using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vivastreet.Migrations
{
    public partial class SelectedAgeEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Advertisements",
                newName: "SelectAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_SelectAgeId",
                table: "Advertisements",
                column: "SelectAgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_selectAges_SelectAgeId",
                table: "Advertisements",
                column: "SelectAgeId",
                principalTable: "selectAges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_selectAges_SelectAgeId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_SelectAgeId",
                table: "Advertisements");

            migrationBuilder.RenameColumn(
                name: "SelectAgeId",
                table: "Advertisements",
                newName: "Age");
        }
    }
}
