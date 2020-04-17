using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class authorBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAuthor",
                schema: "db",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdAuthor",
                schema: "db",
                table: "Books",
                column: "IdAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_IdAuthor",
                schema: "db",
                table: "Books",
                column: "IdAuthor",
                principalSchema: "db",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_IdAuthor",
                schema: "db",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdAuthor",
                schema: "db",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IdAuthor",
                schema: "db",
                table: "Books");
        }
    }
}
