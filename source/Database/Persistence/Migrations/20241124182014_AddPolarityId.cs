using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjKpi.Database.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPolarityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "POLARITY_ID",
                schema: "AJKPI",
                table: "KPIS",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KPIS_POLARITY_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "POLARITY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KPIS_LOOKUP_VALUES_POLARITY_ID",
                schema: "AJKPI",
                table: "KPIS",
                column: "POLARITY_ID",
                principalSchema: "AJKPI",
                principalTable: "LOOKUP_VALUES",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPIS_LOOKUP_VALUES_POLARITY_ID",
                schema: "AJKPI",
                table: "KPIS");

            migrationBuilder.DropIndex(
                name: "IX_KPIS_POLARITY_ID",
                schema: "AJKPI",
                table: "KPIS");

            migrationBuilder.DropColumn(
                name: "POLARITY_ID",
                schema: "AJKPI",
                table: "KPIS");
        }
    }
}
