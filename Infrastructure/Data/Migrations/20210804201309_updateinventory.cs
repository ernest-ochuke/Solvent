using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class updateinventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChipInventories_ChipTypes_ChipTypeId",
                table: "ChipInventories");

            migrationBuilder.DropColumn(
                name: "CurrentBalance",
                table: "ChipInventories");

            migrationBuilder.AlterColumn<int>(
                name: "ChipTypeId",
                table: "ChipInventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChipInventories_ChipTypes_ChipTypeId",
                table: "ChipInventories",
                column: "ChipTypeId",
                principalTable: "ChipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChipInventories_ChipTypes_ChipTypeId",
                table: "ChipInventories");

            migrationBuilder.AlterColumn<int>(
                name: "ChipTypeId",
                table: "ChipInventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CurrentBalance",
                table: "ChipInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ChipInventories_ChipTypes_ChipTypeId",
                table: "ChipInventories",
                column: "ChipTypeId",
                principalTable: "ChipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
