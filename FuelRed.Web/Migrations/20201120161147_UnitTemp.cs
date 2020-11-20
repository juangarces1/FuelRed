using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelRed.Web.Migrations
{
    public partial class UnitTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "Units");

            migrationBuilder.CreateTable(
                name: "UnitTemps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeFuel = table.Column<int>(nullable: false),
                    StartLts = table.Column<int>(nullable: false),
                    EndLts = table.Column<int>(nullable: false),
                    StartPulg = table.Column<int>(nullable: false),
                    EndPulg = table.Column<int>(nullable: false),
                    Buy = table.Column<int>(nullable: false),
                    Fuel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTemps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitTemps");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Units",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fuel",
                table: "Units",
                nullable: true);
        }
    }
}
