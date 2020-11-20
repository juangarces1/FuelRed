using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelRed.Web.Migrations
{
    public partial class ChangeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "UnitTemps");

            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "ItemTankTemps",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "ItemTankTemps");

            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "UnitTemps",
                nullable: false,
                defaultValue: 0);
        }
    }
}
