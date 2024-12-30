using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Database.Persistence.Migrations
{
    /// <inheritdoc />
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class fix : Migration
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DEPARTMENT_ID",
                schema: "TMS",
                table: "USERS");

            migrationBuilder.AlterColumn<int>(
                name: "ROLE",
                schema: "TMS",
                table: "USERS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ROLE",
                schema: "TMS",
                table: "USERS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "DEPARTMENT_ID",
                schema: "TMS",
                table: "USERS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
