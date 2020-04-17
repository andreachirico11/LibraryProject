using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class genreBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGenre",
                schema: "db",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdGenre",
                schema: "db",
                table: "Books",
                column: "IdGenre");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_IdGenre",
                schema: "db",
                table: "Books",
                column: "IdGenre",
                principalSchema: "db",
                principalTable: "Genres",
                principalColumn: "IdGenre",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_IdGenre",
                schema: "db",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdGenre",
                schema: "db",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IdGenre",
                schema: "db",
                table: "Books");
        }
    }
}
