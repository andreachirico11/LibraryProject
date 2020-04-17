using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class seedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "db",
                table: "Users",
                columns: new[] { "IdUser", "Address", "Email", "ImgPath", "IsAdmin", "Name", "Password", "Phone", "Surname" },
                values: new object[,]
                {
                    { 1, "Via Roma, 88", "lorena@email.it", "https://source.unsplash.com/EbQRjuEdFcg", 0, "Lorena", "lorena123", "1234567890", "Schirru" },
                    { 2, "Piazza Italia 8", "pino@email.it", "https://source.unsplash.com/4nulm-JUYFo", 0, "Pino", "pino123", "333123123", "Rossi" },
                    { 3, "VIa della liberta 4", "bianchi@email.it", "https://source.unsplash.com/NAdFJtFFlHE", 0, "Paolo", "bianchi123", null, "Bianchi" },
                    { 4, "Via muccarloa", "benvenuto@email.it", "https://source.unsplash.com/2RhlxwRz4yc", 0, "Simone", "benvenuto123", "0105345345", "Benvenuto" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "db",
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4);
        }
    }
}
