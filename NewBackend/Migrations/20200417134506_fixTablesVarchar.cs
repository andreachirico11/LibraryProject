using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class fixTablesVarchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "db",
                table: "Users",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "db",
                table: "Users",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "db",
                table: "Users",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "db",
                table: "Users",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ImgPath",
                schema: "db",
                table: "Users",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "db",
                table: "Users",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "db",
                table: "Users",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "db",
                table: "Genres",
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
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "db",
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "db",
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "db",
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "ImgPath",
                schema: "db",
                table: "Users",
                type: "varchar",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "db",
                table: "Users",
                type: "varchar",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "db",
                table: "Users",
                type: "varchar",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "db",
                table: "Genres",
                type: "varchar",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }
    }
}
