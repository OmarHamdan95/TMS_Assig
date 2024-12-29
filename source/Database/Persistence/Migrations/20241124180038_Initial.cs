using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AjKpi.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AJKPI");

            migrationBuilder.EnsureSchema(
                name: "AJKPIWf");

            migrationBuilder.CreateTable(
                name: "ATTACHMENT_GROUPS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTACHMENT_GROUPS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true),
                    VALID_FROM = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NAME_AR = table.Column<string>(type: "text", nullable: true),
                    NAME_EN = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOOKUPS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PARENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    LINKS = table.Column<long>(type: "bigint", nullable: true),
                    IS_SYSTEM = table.Column<bool>(type: "boolean", nullable: false),
                    DATA_TYPE = table.Column<string>(type: "text", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true),
                    VALID_FROM = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NAME_AR = table.Column<string>(type: "text", nullable: true),
                    NAME_EN = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOOKUPS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOOKUPS_LOOKUPS_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUPS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "REQUEST_TYPES",
                schema: "AJKPIWf",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CODE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NAME_AR = table.Column<string>(type: "text", nullable: true),
                    NAME_EN = table.Column<string>(type: "text", nullable: true),
                    REQUEST_NUMBER_TEMPLATE = table.Column<string>(type: "text", nullable: true),
                    COMPOSITE_KEY_TEMPLATE = table.Column<string>(type: "text", nullable: true),
                    GLOBAL_COMPOSITE_KEY_TEMPLATE = table.Column<string>(type: "text", nullable: true),
                    PREVENT_CONCURRENT_REQUESTS = table.Column<bool>(type: "boolean", nullable: false),
                    CONCURRENCY_PREVENTED_TYPE_CODES = table.Column<List<string>>(type: "text[]", nullable: false),
                    MAX_ALLOWED_REQUESTS = table.Column<int>(type: "integer", nullable: true),
                    EVENT_QUEUE_NAME = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_MENUS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "text", nullable: true),
                    ICON = table.Column<string>(type: "text", nullable: true),
                    ROUTE = table.Column<string>(type: "text", nullable: true),
                    PERMISSION = table.Column<string>(type: "text", nullable: true),
                    PARENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODULE_CODE = table.Column<string>(type: "text", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_MENUS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYSTEM_MENUS_SYSTEM_MENUS_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalSchema: "AJKPI",
                        principalTable: "SYSTEM_MENUS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ATTACHMENTS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ATTACHMENT_GROUP_ID = table.Column<long>(type: "bigint", nullable: true),
                    FILE_KEY = table.Column<string>(type: "text", nullable: true),
                    FILE_SIZE = table.Column<long>(type: "bigint", nullable: true),
                    FILE_NAME = table.Column<string>(type: "text", nullable: true),
                    ENTITY_CODE = table.Column<string>(type: "text", nullable: true),
                    FILE_PATH = table.Column<string>(type: "text", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTACHMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ATTACHMENTS_ATTACHMENT_GROUPS_ATTACHMENT_GROUP_ID",
                        column: x => x.ATTACHMENT_GROUP_ID,
                        principalSchema: "AJKPI",
                        principalTable: "ATTACHMENT_GROUPS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DEPARTMENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true),
                    VALID_FROM = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NAME_AR = table.Column<string>(type: "text", nullable: true),
                    NAME_EN = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ROLES_DEPARTMENTS_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalSchema: "AJKPI",
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LOOKUP_VALUES",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PARENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    ORDER = table.Column<long>(type: "bigint", nullable: true),
                    IS_SYSTEM = table.Column<bool>(type: "boolean", nullable: false),
                    COLOR = table.Column<string>(type: "text", nullable: true),
                    LOOKUP_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true),
                    VALID_FROM = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NAME_AR = table.Column<string>(type: "text", nullable: true),
                    NAME_EN = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOOKUP_VALUES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOOKUP_VALUES_LOOKUPS_LOOKUP_ID",
                        column: x => x.LOOKUP_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUPS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LOOKUP_VALUES_LOOKUP_VALUES_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "REQUEST_STATUSES",
                schema: "AJKPIWf",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CODE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: true),
                    ACTION_NAME_AR = table.Column<string>(type: "text", nullable: true),
                    ACTION_NAME_EN = table.Column<string>(type: "text", nullable: true),
                    DESCRIPTION_AR = table.Column<string>(type: "text", nullable: true),
                    DESCRIPTION_EN = table.Column<string>(type: "text", nullable: true),
                    ROLES = table.Column<List<string>>(type: "text[]", nullable: false),
                    NEXT_STATUS_CODES = table.Column<List<string>>(type: "text[]", nullable: false),
                    PREVIOUS_STATUS_CODES = table.Column<List<string>>(type: "text[]", nullable: false),
                    IS_STARTING_STATE = table.Column<bool>(type: "boolean", nullable: false),
                    IS_EDITABLE = table.Column<bool>(type: "boolean", nullable: true),
                    IS_DELETABLE = table.Column<bool>(type: "boolean", nullable: true),
                    IS_END_STATE = table.Column<bool>(type: "boolean", nullable: false),
                    IS_ACTION = table.Column<bool>(type: "boolean", nullable: true),
                    COLOR = table.Column<string>(type: "text", nullable: true),
                    CSS_CLASS = table.Column<string>(type: "text", nullable: true),
                    ICON = table.Column<string>(type: "text", nullable: true),
                    REQUEST_TYPE_ID = table.Column<long>(type: "bigint", nullable: false),
                    SELF_ALLOWED = table.Column<bool>(type: "boolean", nullable: false),
                    DEPARTMENT_CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST_STATUSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUEST_STATUSES_REQUEST_TYPES_REQUEST_TYPE_ID",
                        column: x => x.REQUEST_TYPE_ID,
                        principalSchema: "AJKPIWf",
                        principalTable: "REQUEST_TYPES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RequestTypeSearchEntries",
                schema: "AJKPIWf",
                columns: table => new
                {
                    RequestTypeId1 = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "text", nullable: true),
                    PATH = table.Column<string>(type: "text", nullable: true),
                    TYPE = table.Column<string>(type: "text", nullable: true),
                    REQUEST_TYPE_ID = table.Column<string>(type: "text", nullable: true),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypeSearchEntries", x => new { x.RequestTypeId1, x.Id });
                    table.ForeignKey(
                        name: "FK_RequestTypeSearchEntries_REQUEST_TYPES_RequestTypeId1",
                        column: x => x.RequestTypeId1,
                        principalSchema: "AJKPIWf",
                        principalTable: "REQUEST_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ROLE_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true),
                    VALID_FROM = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VALID_TO = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NAME_AR = table.Column<string>(type: "text", nullable: true),
                    NAME_EN = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PERMISSIONS_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "ROLES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USER_NAME = table.Column<string>(type: "text", nullable: true),
                    NAME_AR = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    NAME_EN = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    MOBILE_NUMBER = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    STATUS = table.Column<int>(type: "integer", nullable: false),
                    DEPARTMENT_ID = table.Column<long>(type: "bigint", nullable: false),
                    ROLE_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERS_DEPARTMENTS_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalSchema: "AJKPI",
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "ROLES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "REQUESTS",
                schema: "AJKPIWf",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    COMPOSITE_KEYS = table.Column<List<string>>(type: "text[]", nullable: false),
                    GLOBAL_COMPOSITE_KEYS = table.Column<List<string>>(type: "text[]", nullable: false),
                    EXTERNAL_ID = table.Column<long>(type: "bigint", nullable: false),
                    NUMBER = table.Column<string>(type: "text", nullable: true),
                    NOTE = table.Column<string>(type: "text", nullable: true),
                    DATA = table.Column<string>(type: "text", nullable: true),
                    AUTHOR_TYPE = table.Column<string>(type: "text", nullable: true),
                    AUTHOR_ID = table.Column<string>(type: "text", nullable: true),
                    STATUS_ID = table.Column<long>(type: "bigint", nullable: false),
                    CURRENT_STATUS_DESCRIPTION_AR = table.Column<string>(type: "text", nullable: true),
                    CURRENT_STATUS_DESCRIPTION_EN = table.Column<string>(type: "text", nullable: true),
                    INIT_DEPARTMENT_CODE = table.Column<string>(type: "text", nullable: true),
                    TARGET_DEPARTMENT_CODE = table.Column<string>(type: "text", nullable: true),
                    TARGET_ROLE_CODE = table.Column<string>(type: "text", nullable: true),
                    TYPE_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUESTS_REQUEST_STATUSES_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalSchema: "AJKPIWf",
                        principalTable: "REQUEST_STATUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REQUESTS_REQUEST_TYPES_TYPE_ID",
                        column: x => x.TYPE_ID,
                        principalSchema: "AJKPIWf",
                        principalTable: "REQUEST_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AUTHS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LOGIN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    SALT = table.Column<Guid>(type: "uuid", maxLength: 1000, nullable: false),
                    USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AUTHS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "AJKPI",
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KPIS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NUMBER = table.Column<string>(type: "text", nullable: true),
                    TYPE_ID = table.Column<long>(type: "bigint", nullable: true),
                    KPI_TYPE_ID = table.Column<long>(type: "bigint", nullable: true),
                    MEASUREMENT_UNIT_ID = table.Column<long>(type: "bigint", nullable: true),
                    MATHEMATICAL_EQUATION_AB_ID = table.Column<long>(type: "bigint", nullable: true),
                    NAME_AR = table.Column<string>(type: "text", nullable: true),
                    NAME_EN = table.Column<string>(type: "text", nullable: true),
                    DESCRIPTION_AR = table.Column<string>(type: "text", nullable: true),
                    DESCRIPTION_EN = table.Column<string>(type: "text", nullable: true),
                    MEASUREMENT_CYCLE_ID = table.Column<long>(type: "bigint", nullable: true),
                    DESCRIPTION_A_AR = table.Column<string>(type: "text", nullable: true),
                    DESCRIPTION_A_EN = table.Column<string>(type: "text", nullable: true),
                    DESCRIPTION_B_AR = table.Column<string>(type: "text", nullable: true),
                    DESCRIPTION_B_EN = table.Column<string>(type: "text", nullable: true),
                    INDICATOR_MODULARITY_ID = table.Column<long>(type: "bigint", nullable: true),
                    IS_PRIVET = table.Column<bool>(type: "boolean", nullable: true),
                    STATISTICAL_INDICATOR = table.Column<bool>(type: "boolean", nullable: true),
                    INDEX_CREATION_RATE_ID = table.Column<long>(type: "bigint", nullable: true),
                    INDEX_SOURCE_ID = table.Column<long>(type: "bigint", nullable: true),
                    INDEX_CLASS_ID = table.Column<long>(type: "bigint", nullable: true),
                    BALANCED_SCORED_ID = table.Column<long>(type: "bigint", nullable: true),
                    RELATED_STRATIGIC_GOAL_ID = table.Column<long>(type: "bigint", nullable: true),
                    FIRST_RESULT_SOURCE_ID = table.Column<long>(type: "bigint", nullable: true),
                    FIRST_RESULT = table.Column<decimal>(type: "numeric", nullable: true),
                    PERCANTAGE = table.Column<decimal>(type: "numeric", nullable: true),
                    FIRST_RESULT_DETAILS = table.Column<string>(type: "text", nullable: true),
                    OWNER_DEPARTEMNT_ID = table.Column<long>(type: "bigint", nullable: true),
                    OPERATION_ACTION_ID = table.Column<long>(type: "bigint", nullable: true),
                    REQUEST_ID = table.Column<long>(type: "bigint", nullable: true),
                    STATUS_ID = table.Column<long>(type: "bigint", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    INPUT_METHOD_ID = table.Column<long>(type: "bigint", nullable: true),
                    AGGREGATE_COEFFICIENT_VALUES_METHOD_A_ID = table.Column<long>(type: "bigint", nullable: true),
                    AGGREGATE_COEFFICIENT_VALUES_METHOD_B_ID = table.Column<long>(type: "bigint", nullable: true),
                    POLITICS_ID = table.Column<long>(type: "bigint", nullable: true),
                    QUALITY_OF_LIFE_ID = table.Column<long>(type: "bigint", nullable: true),
                    RISK_ID = table.Column<long>(type: "bigint", nullable: true),
                    SUSTAINABLE_DEVELOPMENT_GOALS_ID = table.Column<long>(type: "bigint", nullable: true),
                    SUSTAINABLE_DEVELOPMENT_GOAL_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KPIS_DEPARTMENTS_OWNER_DEPARTEMNT_ID",
                        column: x => x.OWNER_DEPARTEMNT_ID,
                        principalSchema: "AJKPI",
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_AGGREGATE_COEFFICIENT_VALUES_METHOD_A_ID",
                        column: x => x.AGGREGATE_COEFFICIENT_VALUES_METHOD_A_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_AGGREGATE_COEFFICIENT_VALUES_METHOD_B_ID",
                        column: x => x.AGGREGATE_COEFFICIENT_VALUES_METHOD_B_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_BALANCED_SCORED_ID",
                        column: x => x.BALANCED_SCORED_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_FIRST_RESULT_SOURCE_ID",
                        column: x => x.FIRST_RESULT_SOURCE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_INDEX_CLASS_ID",
                        column: x => x.INDEX_CLASS_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_INDEX_CREATION_RATE_ID",
                        column: x => x.INDEX_CREATION_RATE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_INDEX_SOURCE_ID",
                        column: x => x.INDEX_SOURCE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_INDICATOR_MODULARITY_ID",
                        column: x => x.INDICATOR_MODULARITY_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_INPUT_METHOD_ID",
                        column: x => x.INPUT_METHOD_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_KPI_TYPE_ID",
                        column: x => x.KPI_TYPE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_MATHEMATICAL_EQUATION_AB_ID",
                        column: x => x.MATHEMATICAL_EQUATION_AB_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_MEASUREMENT_CYCLE_ID",
                        column: x => x.MEASUREMENT_CYCLE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_MEASUREMENT_UNIT_ID",
                        column: x => x.MEASUREMENT_UNIT_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_OPERATION_ACTION_ID",
                        column: x => x.OPERATION_ACTION_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_POLITICS_ID",
                        column: x => x.POLITICS_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_QUALITY_OF_LIFE_ID",
                        column: x => x.QUALITY_OF_LIFE_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_RELATED_STRATIGIC_GOAL_ID",
                        column: x => x.RELATED_STRATIGIC_GOAL_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_RISK_ID",
                        column: x => x.RISK_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_LOOKUP_VALUES_SUSTAINABLE_DEVELOPMENT_GOALS_ID",
                        column: x => x.SUSTAINABLE_DEVELOPMENT_GOALS_ID,
                        principalSchema: "AJKPI",
                        principalTable: "LOOKUP_VALUES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_REQUESTS_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalSchema: "AJKPIWf",
                        principalTable: "REQUESTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KPIS_REQUEST_TYPES_TYPE_ID",
                        column: x => x.TYPE_ID,
                        principalSchema: "AJKPIWf",
                        principalTable: "REQUEST_TYPES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WF_TRANSACTIONS",
                schema: "AJKPIWf",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    REQUEST_ID = table.Column<long>(type: "bigint", nullable: true),
                    COMMENT = table.Column<string>(type: "text", nullable: true),
                    ACTION = table.Column<string>(type: "text", nullable: true),
                    OLD_STATUS_CODE = table.Column<string>(type: "text", nullable: true),
                    OLD_STATUS_DESCRIPTION_AR = table.Column<string>(type: "text", nullable: true),
                    OLD_STATUS_DESCRIPTION_EN = table.Column<string>(type: "text", nullable: true),
                    NEW_STATUS_CODE = table.Column<string>(type: "text", nullable: true),
                    NEW_STATUS_DESCRIPTION_AR = table.Column<string>(type: "text", nullable: true),
                    NEW_STATUS_DESCRIPTION_EN = table.Column<string>(type: "text", nullable: true),
                    DEPARTMENT_CODE = table.Column<string>(type: "text", nullable: true),
                    ROLE_CODE = table.Column<string>(type: "text", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_TRANSACTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WF_TRANSACTIONS_REQUESTS_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalSchema: "AJKPIWf",
                        principalTable: "REQUESTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KPI_TASKS",
                schema: "AJKPI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KPI_ID = table.Column<long>(type: "bigint", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    A_VALUE = table.Column<long>(type: "bigint", nullable: true),
                    B_VALUE = table.Column<long>(type: "bigint", nullable: true),
                    RESULT_VALUE = table.Column<decimal>(type: "numeric", nullable: true),
                    TARGET = table.Column<long>(type: "bigint", nullable: true),
                    VERIFICATION_RATE = table.Column<decimal>(type: "numeric", nullable: true),
                    IS_LOCKED = table.Column<bool>(type: "boolean", nullable: true),
                    CREATED_BY = table.Column<string>(type: "text", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "text", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "boolean", nullable: false),
                    CODE = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPI_TASKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KPI_TASKS_KPIS_KPI_ID",
                        column: x => x.KPI_ID,
                        principalSchema: "AJKPI",
                        principalTable: "KPIS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATTACHMENTS_ATTACHMENT_GROUP_ID",
                schema: "AJKPI",
                table: "ATTACHMENTS",
                column: "ATTACHMENT_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AUTHS_LOGIN",
                schema: "AJKPI",
                table: "AUTHS",
                column: "LOGIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUTHS_SALT",
                schema: "AJKPI",
                table: "AUTHS",
                column: "SALT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AUTHS_USER_ID",
                schema: "AJKPI",
                table: "AUTHS",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KPI_TASKS_KPI_ID",
                schema: "AJKPI",
                table: "KPI_TASKS",
                column: "KPI_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_AGGREGATE_COEFFICIENT_VALUES_METHOD_A_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "AGGREGATE_COEFFICIENT_VALUES_METHOD_A_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_AGGREGATE_COEFFICIENT_VALUES_METHOD_B_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "AGGREGATE_COEFFICIENT_VALUES_METHOD_B_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_BALANCED_SCORED_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "BALANCED_SCORED_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_FIRST_RESULT_SOURCE_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "FIRST_RESULT_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_INDEX_CLASS_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "INDEX_CLASS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_INDEX_CREATION_RATE_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "INDEX_CREATION_RATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_INDEX_SOURCE_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "INDEX_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_INDICATOR_MODULARITY_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "INDICATOR_MODULARITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_INPUT_METHOD_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "INPUT_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_KPI_TYPE_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "KPI_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_MATHEMATICAL_EQUATION_AB_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "MATHEMATICAL_EQUATION_AB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_MEASUREMENT_CYCLE_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "MEASUREMENT_CYCLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_MEASUREMENT_UNIT_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "MEASUREMENT_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_OPERATION_ACTION_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "OPERATION_ACTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_OWNER_DEPARTEMNT_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "OWNER_DEPARTEMNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_POLITICS_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "POLITICS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_QUALITY_OF_LIFE_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "QUALITY_OF_LIFE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_RELATED_STRATIGIC_GOAL_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "RELATED_STRATIGIC_GOAL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_REQUEST_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_RISK_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "RISK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_STATUS_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_SUSTAINABLE_DEVELOPMENT_GOALS_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "SUSTAINABLE_DEVELOPMENT_GOALS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_TYPE_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUP_VALUES_LOOKUP_ID",
                schema: "AJKPI",
                table: "LOOKUP_VALUES",
                column: "LOOKUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUP_VALUES_PARENT_ID",
                schema: "AJKPI",
                table: "LOOKUP_VALUES",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUPS_PARENT_ID",
                schema: "AJKPI",
                table: "LOOKUPS",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSIONS_ROLE_ID",
                schema: "AJKPI",
                table: "PERMISSIONS",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_STATUSES_CODE_REQUEST_TYPE_ID",
                schema: "AJKPIWf",
                table: "REQUEST_STATUSES",
                columns: new[] { "CODE", "REQUEST_TYPE_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_STATUSES_REQUEST_TYPE_ID",
                schema: "AJKPIWf",
                table: "REQUEST_STATUSES",
                column: "REQUEST_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_TYPES_CODE",
                schema: "AJKPIWf",
                table: "REQUEST_TYPES",
                column: "CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_NUMBER",
                schema: "AJKPIWf",
                table: "REQUESTS",
                column: "NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_STATUS_ID",
                schema: "AJKPIWf",
                table: "REQUESTS",
                column: "STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_TYPE_ID",
                schema: "AJKPIWf",
                table: "REQUESTS",
                column: "TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_DEPARTMENT_ID",
                schema: "AJKPI",
                table: "ROLES",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_MENUS_PARENT_ID",
                schema: "AJKPI",
                table: "SYSTEM_MENUS",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_DEPARTMENT_ID",
                schema: "AJKPI",
                table: "USERS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                schema: "AJKPI",
                table: "USERS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLE_ID",
                schema: "AJKPI",
                table: "USERS",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WF_TRANSACTIONS_REQUEST_ID",
                schema: "AJKPIWf",
                table: "WF_TRANSACTIONS",
                column: "REQUEST_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATTACHMENTS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "AUTHS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "KPI_TASKS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "PERMISSIONS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "RequestTypeSearchEntries",
                schema: "AJKPIWf");

            migrationBuilder.DropTable(
                name: "SYSTEM_MENUS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "WF_TRANSACTIONS",
                schema: "AJKPIWf");

            migrationBuilder.DropTable(
                name: "ATTACHMENT_GROUPS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "KPIS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "ROLES",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "LOOKUP_VALUES",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "REQUESTS",
                schema: "AJKPIWf");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "LOOKUPS",
                schema: "AJKPI");

            migrationBuilder.DropTable(
                name: "REQUEST_STATUSES",
                schema: "AJKPIWf");

            migrationBuilder.DropTable(
                name: "REQUEST_TYPES",
                schema: "AJKPIWf");
        }
    }
}
