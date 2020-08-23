using Microsoft.EntityFrameworkCore.Migrations;

namespace OdeToFood.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Location = table.Column<string>(maxLength: 255, nullable: false),
                    CuisineType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "CuisineType", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Medellín, Colombia", "Jader's Pizza" },
                    { 2, 3, "Medellín, Colombia", "Julieta's Indian Food" },
                    { 3, 1, "Medellín, Colombia", "Natalia's Mexican" },
                    { 4, 2, "Medellín, Colombia", "Cano's Restaurant" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
