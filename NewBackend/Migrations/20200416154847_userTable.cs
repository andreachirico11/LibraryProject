using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class userTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                schema: "db",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    IsAdmin = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    ImgPath = table.Column<string>(type: "varchar", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "db");
        }
    }
}
