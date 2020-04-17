using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class seedgenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                schema: "db",
                table: "Genres",
                columns: new[] { "IdGenre", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Storico" },
                    { 3, "Saggistica" },
                    { 4, "Informatica" },
                    { 5, "Diritto" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "db",
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Genres",
                keyColumn: "IdGenre",
                keyValue: 5);

           
        }
    }
}
