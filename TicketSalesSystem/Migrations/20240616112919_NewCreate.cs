using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class NewCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_RouteId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Stations");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Trains",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasWifi",
                table: "Trains",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Trains",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalStation",
                table: "Routes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureStation",
                table: "Routes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "Routes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteStations",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false),
                    StationsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStations", x => new { x.RouteId, x.StationsId });
                    table.ForeignKey(
                        name: "FK_RouteStations_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteStations_Stations_StationsId",
                        column: x => x.StationsId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trains_BrandId",
                table: "Trains",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_ModelId",
                table: "Trains",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TrainId",
                table: "Routes",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStations_StationsId",
                table: "RouteStations",
                column: "StationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Brands_BrandId",
                table: "Trains",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Models_ModelId",
                table: "Trains",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Brands_BrandId",
                table: "Trains");

            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Models_ModelId",
                table: "Trains");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "RouteStations");

            migrationBuilder.DropIndex(
                name: "IX_Trains_BrandId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Trains_ModelId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TrainId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "HasWifi",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "ArrivalStation",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DepartureStation",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Routes");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Trains",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Trains",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Stations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RouteId",
                table: "Stations",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
