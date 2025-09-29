using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HWW8WithEF.Migrations
{
    /// <inheritdoc />
    public partial class addentityrestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantId",
                table: "Foods",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Restaurant_RestaurantId",
                table: "Foods",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Restaurant_RestaurantId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Foods_RestaurantId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Foods");
        }
    }
}
