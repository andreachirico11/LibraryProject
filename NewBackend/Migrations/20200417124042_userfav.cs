using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class userfav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favourites",
                schema: "db",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdBook = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.IdUser, x.IdBook });
                    table.ForeignKey(
                        name: "FK_Favourites_Books_IdBook",
                        column: x => x.IdBook,
                        principalSchema: "db",
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_Users_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "db",
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_IdBook",
                schema: "db",
                table: "Favourites",
                column: "IdBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourites",
                schema: "db");
        }
    }
}
