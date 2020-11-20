using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelRed.Web.Migrations
{
    public partial class NewFieldUnitTemps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "UnitTemps",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "UnitTemps");
        }
    }
}
