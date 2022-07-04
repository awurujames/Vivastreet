using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vivastreet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PostCode = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowPhoneNumber = table.Column<bool>(type: "bit", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremierBanner = table.Column<bool>(type: "bit", nullable: false),
                    AddvertOTheWeek = table.Column<bool>(type: "bit", nullable: false),
                    ClassicAdvert = table.Column<bool>(type: "bit", nullable: false),
                    French = table.Column<bool>(type: "bit", nullable: false),
                    Italian = table.Column<bool>(type: "bit", nullable: false),
                    Spanish = table.Column<bool>(type: "bit", nullable: false),
                    German = table.Column<bool>(type: "bit", nullable: false),
                    Chinese = table.Column<bool>(type: "bit", nullable: false),
                    Russian = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<bool>(type: "bit", nullable: false),
                    English = table.Column<bool>(type: "bit", nullable: false),
                    Portugese = table.Column<bool>(type: "bit", nullable: false),
                    IsDeliveryService = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryServiceFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickUpServiceFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPickUpService = table.Column<bool>(type: "bit", nullable: false),
                    IsInstallationService = table.Column<bool>(type: "bit", nullable: false),
                    InstallationServiceFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Langauges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    English = table.Column<bool>(type: "bit", nullable: false),
                    Italian = table.Column<bool>(type: "bit", nullable: false),
                    Russian = table.Column<bool>(type: "bit", nullable: false),
                    Spanish = table.Column<bool>(type: "bit", nullable: false),
                    German = table.Column<bool>(type: "bit", nullable: false),
                    Chinese = table.Column<bool>(type: "bit", nullable: false),
                    French = table.Column<bool>(type: "bit", nullable: false),
                    Portugese = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<bool>(type: "bit", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langauges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Langauges_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delivery = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LocalPickUp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "selectAges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_selectAges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_selectAges_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOffereds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectAll = table.Column<bool>(type: "bit", nullable: false),
                    Delivery = table.Column<bool>(type: "bit", nullable: false),
                    Pickup = table.Column<bool>(type: "bit", nullable: false),
                    Instalation = table.Column<bool>(type: "bit", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOffereds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOffereds_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_AdvertisementId",
                table: "Conditions",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Langauges_AdvertisementId",
                table: "Langauges",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_AdvertisementId",
                table: "Materials",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_AdvertisementId",
                table: "Rates",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_selectAges_AdvertisementId",
                table: "selectAges",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffereds_AdvertisementId",
                table: "ServiceOffereds",
                column: "AdvertisementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Langauges");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "selectAges");

            migrationBuilder.DropTable(
                name: "ServiceOffereds");

            migrationBuilder.DropTable(
                name: "Advertisements");
        }
    }
}
