using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelRed.Web.Migrations
{
    public partial class UserStaion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StationId",
                table: "AspNetUsers",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stations_StationId",
                table: "AspNetUsers",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stations_StationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "AspNetUsers");
        }
    }
}
