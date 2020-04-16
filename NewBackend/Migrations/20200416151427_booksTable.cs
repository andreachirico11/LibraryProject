using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class booksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Books",
                schema: "db",
                columns: table => new
                {
                    IdBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Editor = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    PublishingYear = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar", maxLength: 500, nullable: true),
                    Isbn = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IdBook);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "db");


        }
    }
}
