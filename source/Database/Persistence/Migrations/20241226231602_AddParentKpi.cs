using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjKpi.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddParentKpi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPIS_LOOKUP_VALUES_SUSTAINABLE_DEVELOPMENT_GOALS_ID",
                schema: "AJKPI",
                table: "KPIS");

            migrationBuilder.RenameColumn(
                name: "SUSTAINABLE_DEVELOPMENT_GOALS_ID",
                schema: "AJKPI",
                table: "KPIS",
                newName: "PARENT_KPI_ID");

            migrationBuilder.RenameIndex(
                name: "IX_KPIS_SUSTAINABLE_DEVELOPMENT_GOALS_ID",
                schema: "AJKPI",
                table: "KPIS",
                newName: "IX_KPIS_PARENT_KPI_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_SUSTAINABLE_DEVELOPMENT_GOAL_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "SUSTAINABLE_DEVELOPMENT_GOAL_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KPIS_KPIS_PARENT_KPI_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "PARENT_KPI_ID",
                principalSchema: "AJKPI",
                principalTable: "KPIS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KPIS_LOOKUP_VALUES_SUSTAINABLE_DEVELOPMENT_GOAL_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "SUSTAINABLE_DEVELOPMENT_GOAL_ID",
                principalSchema: "AJKPI",
                principalTable: "LOOKUP_VALUES",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPIS_KPIS_PARENT_KPI_ID",
                schema: "AJKPI",
                table: "KPIS");

            migrationBuilder.DropForeignKey(
                name: "FK_KPIS_LOOKUP_VALUES_SUSTAINABLE_DEVELOPMENT_GOAL_ID",
                schema: "AJKPI",
                table: "KPIS");

            migrationBuilder.DropIndex(
                name: "IX_KPIS_SUSTAINABLE_DEVELOPMENT_GOAL_ID",
                schema: "AJKPI",
                table: "KPIS");

            migrationBuilder.RenameColumn(
                name: "PARENT_KPI_ID",
                schema: "AJKPI",
                table: "KPIS",
                newName: "SUSTAINABLE_DEVELOPMENT_GOALS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_KPIS_PARENT_KPI_ID",
                schema: "AJKPI",
                table: "KPIS",
                newName: "IX_KPIS_SUSTAINABLE_DEVELOPMENT_GOALS_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KPIS_LOOKUP_VALUES_SUSTAINABLE_DEVELOPMENT_GOALS_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "SUSTAINABLE_DEVELOPMENT_GOALS_ID",
                principalSchema: "AJKPI",
                principalTable: "LOOKUP_VALUES",
                principalColumn: "ID");
        }
    }
}
