using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class ta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_EndStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_StartStationId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_EndStationId",
                table: "Tickets",
                column: "EndStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_StartStationId",
                table: "Tickets",
                column: "StartStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_EndStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_StartStationId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_EndStationId",
                table: "Tickets",
                column: "EndStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_StartStationId",
                table: "Tickets",
                column: "StartStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
