using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class loanrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                schema: "db",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "db",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                schema: "db",
                table: "Loans",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                schema: "db",
                table: "Loans",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_BookId",
                schema: "db",
                table: "Loans",
                column: "BookId",
                principalSchema: "db",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_UserId",
                schema: "db",
                table: "Loans",
                column: "UserId",
                principalSchema: "db",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_BookId",
                schema: "db",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_UserId",
                schema: "db",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BookId",
                schema: "db",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                schema: "db",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BookId",
                schema: "db",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "db",
                table: "Loans");
        }
    }
}
