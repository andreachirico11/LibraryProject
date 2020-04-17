using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class seedAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "db",
                table: "Authors",
                columns: new[] { "IdAuthor", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Agatha", "Christie" },
                    { 2, "Carlo", "Capra" },
                    { 3, "Giovanni", "Sabatucci" },
                    { 4, "Alessandro", "Bellini" },
                    { 5, "Sarah", "Gailey" },
                    { 6, "Steven", "Levy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "db",
                table: "Authors",
                keyColumn: "IdAuthor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Authors",
                keyColumn: "IdAuthor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Authors",
                keyColumn: "IdAuthor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Authors",
                keyColumn: "IdAuthor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Authors",
                keyColumn: "IdAuthor",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Authors",
                keyColumn: "IdAuthor",
                keyValue: 6);
        }
    }
}
