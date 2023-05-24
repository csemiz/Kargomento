using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargomentoDL.Migrations
{
    /// <inheritdoc />
    public partial class FKaddedagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CargoId",
                table: "CargoStatusProcesses",
                type: "nvarchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStatusProcesses_CargoId",
                table: "CargoStatusProcesses",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoStatusProcesses_Cargos_CargoId",
                table: "CargoStatusProcesses",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoStatusProcesses_Cargos_CargoId",
                table: "CargoStatusProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CargoStatusProcesses_CargoId",
                table: "CargoStatusProcesses");

            migrationBuilder.AlterColumn<string>(
                name: "CargoId",
                table: "CargoStatusProcesses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)");
        }
    }
}
