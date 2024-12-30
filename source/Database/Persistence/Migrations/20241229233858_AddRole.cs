using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ROLE_ID",
                schema: "TMS",
                table: "USERS");

            migrationBuilder.AddColumn<int>(
                name: "ROLE",
                schema: "TMS",
                table: "USERS",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ROLE",
                schema: "TMS",
                table: "USERS");

            migrationBuilder.AddColumn<long>(
                name: "ROLE_ID",
                schema: "TMS",
                table: "USERS",
                type: "bigint",
                nullable: true);
        }
    }
}
