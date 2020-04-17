using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBackend.Migrations
{
    public partial class fixBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "db",
                table: "Books",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                schema: "db",
                table: "Books",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Editor",
                schema: "db",
                table: "Books",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "db",
                table: "Books",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 500,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "db",
                table: "Books",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                schema: "db",
                table: "Books",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Editor",
                schema: "db",
                table: "Books",
                type: "varchar",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "db",
                table: "Books",
                type: "varchar",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

        }
    }
}
