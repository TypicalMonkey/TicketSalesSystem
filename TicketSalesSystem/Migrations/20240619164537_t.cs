using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "EndStationId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartStationId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EndStationId",
                table: "Tickets",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RouteId",
                table: "Tickets",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StartStationId",
                table: "Tickets",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Routes_RouteId",
                table: "Tickets",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Routes_RouteId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_EndStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_StartStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EndStationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RouteId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_StartStationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EndStationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "StartStationId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "TrainId");
        }
    }
}
