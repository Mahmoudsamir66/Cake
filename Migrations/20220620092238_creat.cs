using Microsoft.EntityFrameworkCore.Migrations;

namespace Cake.Migrations
{
    public partial class creat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    ImageFileName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "ImageFileName", "name", "price" },
                values: new object[] { 1, "very good", "cake.jpg", "cake", 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "ImageFileName", "name", "price" },
                values: new object[] { 2, "very simple", "baker.jpg", "baker", 10m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "ImageFileName", "name", "price" },
                values: new object[] { 3, "very simple", "baker.jpg", "baker", 122m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "ImageFileName", "name", "price" },
                values: new object[] { 4, "very simple", "a.jpg", "baker", 50m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "ImageFileName", "name", "price" },
                values: new object[] { 5, "very simple", "b.jpg", "baker", 60m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "ImageFileName", "name", "price" },
                values: new object[] { 6, "very simple", "c.jpg", "baker", 1000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "description", "ImageFileName", "name", "price" },
                values: new object[] { 7, "very simple", "d.jpg", "baker", 105m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
