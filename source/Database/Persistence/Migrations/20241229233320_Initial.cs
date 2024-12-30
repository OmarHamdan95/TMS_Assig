using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TMS");

            migrationBuilder.CreateTable(
                name: "LOOKUPS",
                schema: "TMS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    LINKS = table.Column<long>(type: "bigint", nullable: true),
                    IS_SYSTEM = table.Column<bool>(type: "bit", nullable: false),
                    DATA_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VALID_FROM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NAME_AR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAME_EN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOOKUPS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOOKUPS_LOOKUPS_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalSchema: "TMS",
                        principalTable: "LOOKUPS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "TMS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAME_AR = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NAME_EN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MOBILE_NUMBER = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    DEPARTMENT_ID = table.Column<long>(type: "bigint", nullable: false),
                    ROLE_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOOKUP_VALUES",
                schema: "TMS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    ORDER = table.Column<long>(type: "bigint", nullable: true),
                    IS_SYSTEM = table.Column<bool>(type: "bit", nullable: false),
                    COLOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOOKUP_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VALID_FROM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NAME_AR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAME_EN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOOKUP_VALUES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOOKUP_VALUES_LOOKUPS_LOOKUP_ID",
                        column: x => x.LOOKUP_ID,
                        principalSchema: "TMS",
                        principalTable: "LOOKUPS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LOOKUP_VALUES_LOOKUP_VALUES_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalSchema: "TMS",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AUTHS",
                schema: "TMS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SALT = table.Column<Guid>(type: "uniqueidentifier", maxLength: 1000, nullable: false),
                    USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AUTHS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "TMS",
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TASKS",
                schema: "TMS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    PRIORITY = table.Column<int>(type: "int", nullable: true),
                    DUE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ASSIGNED_TO_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TASKS_USERS_ASSIGNED_TO_ID",
                        column: x => x.ASSIGNED_TO_ID,
                        principalSchema: "TMS",
                        principalTable: "USERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUTHS_LOGIN",
                schema: "TMS",
                table: "AUTHS",
                column: "LOGIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUTHS_SALT",
                schema: "TMS",
                table: "AUTHS",
                column: "SALT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUTHS_USER_ID",
                schema: "TMS",
                table: "AUTHS",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUP_VALUES_LOOKUP_ID",
                schema: "TMS",
                table: "LOOKUP_VALUES",
                column: "LOOKUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUP_VALUES_PARENT_ID",
                schema: "TMS",
                table: "LOOKUP_VALUES",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUPS_PARENT_ID",
                schema: "TMS",
                table: "LOOKUPS",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TASKS_ASSIGNED_TO_ID",
                schema: "TMS",
                table: "TASKS",
                column: "ASSIGNED_TO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                schema: "TMS",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUTHS",
                schema: "TMS");

            migrationBuilder.DropTable(
                name: "LOOKUP_VALUES",
                schema: "TMS");

            migrationBuilder.DropTable(
                name: "TASKS",
                schema: "TMS");

            migrationBuilder.DropTable(
                name: "LOOKUPS",
                schema: "TMS");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "TMS");
        }
    }
}
