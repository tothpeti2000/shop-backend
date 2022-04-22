using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class CustomerToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_CustomerId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Cart",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Review",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                newName: "IX_Cart_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
