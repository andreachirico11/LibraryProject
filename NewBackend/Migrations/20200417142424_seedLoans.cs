using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class seedLoans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "db",
                table: "Loans",
                columns: new[] { "IdLoan", "BookId", "DateReturn", "DateStart", "UserId" },
                values: new object[] { 1, 1, new DateTime(2020, 4, 7, 19, 17, 25, 890, DateTimeKind.Unspecified).AddTicks(9926), new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                schema: "db",
                table: "Loans",
                columns: new[] { "IdLoan", "BookId", "DateReturn", "DateStart", "UserId" },
                values: new object[] { 2, 2, null, new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "db",
                table: "Loans",
                keyColumn: "IdLoan",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "db",
                table: "Loans",
                keyColumn: "IdLoan",
                keyValue: 2);
        }
    }
}
