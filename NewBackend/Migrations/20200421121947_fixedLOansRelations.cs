using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class fixedLOansRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Loans_BookId",
                schema: "db",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                schema: "db",
                table: "Loans");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                schema: "db",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                schema: "db",
                table: "Loans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Loans_BookId",
                schema: "db",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                schema: "db",
                table: "Loans");

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
        }
    }
}
