using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class authorsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "db",
                table: "Authors",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "db",
                table: "Authors",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "db",
                table: "Authors",
                type: "varchar",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "db",
                table: "Authors",
                type: "varchar",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }
    }
}
