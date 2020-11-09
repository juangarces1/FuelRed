using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelRed.Web.Migrations
{
    public partial class LChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementItems");

            migrationBuilder.DropTable(
                name: "MeasurementItemTemps");

            migrationBuilder.DropTable(
                name: "Measurements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementItemTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Combustible = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Dispenser = table.Column<string>(nullable: true),
                    DispenserId = table.Column<int>(nullable: false),
                    Hose = table.Column<string>(nullable: true),
                    HoseId = table.Column<int>(nullable: false),
                    Medida1 = table.Column<string>(nullable: true),
                    Medida2 = table.Column<string>(nullable: true),
                    Medida3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementItemTemps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    HourEnd = table.Column<DateTime>(nullable: false),
                    HourStart = table.Column<DateTime>(nullable: false),
                    StationId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Measurements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Combustible = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Dispenser = table.Column<string>(nullable: true),
                    DispenserEntityId = table.Column<int>(nullable: true),
                    DispenserId = table.Column<int>(nullable: false),
                    Hose = table.Column<string>(nullable: true),
                    HoseId = table.Column<int>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: true),
                    Medida1 = table.Column<string>(nullable: true),
                    Medida2 = table.Column<string>(nullable: true),
                    Medida3 = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementItems_Dispensers_DispenserEntityId",
                        column: x => x.DispenserEntityId,
                        principalTable: "Dispensers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeasurementItems_Measurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementItems_DispenserEntityId",
                table: "MeasurementItems",
                column: "DispenserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementItems_MeasurementId",
                table: "MeasurementItems",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_StationId",
                table: "Measurements",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_UserId",
                table: "Measurements",
                column: "UserId");
        }
    }
}
