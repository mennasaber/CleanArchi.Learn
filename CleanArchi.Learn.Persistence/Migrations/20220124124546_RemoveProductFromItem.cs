using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchi.Learn.Persistence.Migrations
{
    public partial class RemoveProductFromItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ProductId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Products_ProductId",
                table: "Items",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
