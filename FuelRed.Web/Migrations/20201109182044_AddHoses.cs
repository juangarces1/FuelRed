using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelRed.Web.Migrations
{
    public partial class AddHoses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoseEntity_Dispensers_DispenserEntityId",
                table: "HoseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoseEntity",
                table: "HoseEntity");

            migrationBuilder.RenameTable(
                name: "HoseEntity",
                newName: "Hoses");

            migrationBuilder.RenameIndex(
                name: "IX_HoseEntity_DispenserEntityId",
                table: "Hoses",
                newName: "IX_Hoses_DispenserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoses",
                table: "Hoses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hoses_Dispensers_DispenserEntityId",
                table: "Hoses",
                column: "DispenserEntityId",
                principalTable: "Dispensers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hoses_Dispensers_DispenserEntityId",
                table: "Hoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoses",
                table: "Hoses");

            migrationBuilder.RenameTable(
                name: "Hoses",
                newName: "HoseEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Hoses_DispenserEntityId",
                table: "HoseEntity",
                newName: "IX_HoseEntity_DispenserEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoseEntity",
                table: "HoseEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoseEntity_Dispensers_DispenserEntityId",
                table: "HoseEntity",
                column: "DispenserEntityId",
                principalTable: "Dispensers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
