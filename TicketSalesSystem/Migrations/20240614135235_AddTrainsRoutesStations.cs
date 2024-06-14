using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainsRoutesStations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_Routes_RouteId",
                table: "Station");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Station",
                table: "Station");

            migrationBuilder.RenameTable(
                name: "Station",
                newName: "Stations");

            migrationBuilder.RenameIndex(
                name: "IX_Station_RouteId",
                table: "Stations",
                newName: "IX_Stations_RouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stations",
                table: "Stations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stations",
                table: "Stations");

            migrationBuilder.RenameTable(
                name: "Stations",
                newName: "Station");

            migrationBuilder.RenameIndex(
                name: "IX_Stations_RouteId",
                table: "Station",
                newName: "IX_Station_RouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Station",
                table: "Station",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_Routes_RouteId",
                table: "Station",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
