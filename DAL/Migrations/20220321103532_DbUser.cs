using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class DbUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUser_UserID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserID",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Review");

            migrationBuilder.DropTable(
                name: "AspNetUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AspNetUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserID",
                table: "Review",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUser_UserID",
                table: "Review",
                column: "UserID",
                principalTable: "AspNetUser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
