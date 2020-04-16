using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class relationBookFav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favourites",
                schema: "db",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdBook = table.Column<int>(nullable: false),
                    UserIdUser = table.Column<int>(nullable: true),
                    BookIdBook = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.IdUser, x.IdBook });
                    table.ForeignKey(
                        name: "FK_Favourites_Books_BookIdBook",
                        column: x => x.BookIdBook,
                        principalSchema: "db",
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favourites_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_BookIdBook",
                schema: "db",
                table: "Favourites",
                column: "BookIdBook");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserIdUser",
                schema: "db",
                table: "Favourites",
                column: "UserIdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourites",
                schema: "db");
        }
    }
}
