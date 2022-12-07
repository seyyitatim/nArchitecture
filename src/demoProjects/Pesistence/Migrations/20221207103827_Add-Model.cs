using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modals_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modals",
                columns: new[] { "Id", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[] { 1, 1, 1500m, "", "Series 1" });

            migrationBuilder.InsertData(
                table: "Modals",
                columns: new[] { "Id", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[] { 2, 1, 1200m, "", "Series 2" });

            migrationBuilder.InsertData(
                table: "Modals",
                columns: new[] { "Id", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[] { 3, 2, 1000m, "", "A180" });

            migrationBuilder.CreateIndex(
                name: "IX_Modals_BrandId",
                table: "Modals",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modals");
        }
    }
}
