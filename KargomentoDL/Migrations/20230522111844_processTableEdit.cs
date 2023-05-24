using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargomentoDL.Migrations
{
    /// <inheritdoc />
    public partial class processTableEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoStatusProcesses_AspNetUsers_AppUserId",
                table: "CargoStatusProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CargoStatusProcesses_AppUserId",
                table: "CargoStatusProcesses");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CargoStatusProcesses");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "CargoStatusProcesses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStatusProcesses_EmployeeId",
                table: "CargoStatusProcesses",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoStatusProcesses_AspNetUsers_EmployeeId",
                table: "CargoStatusProcesses",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoStatusProcesses_AspNetUsers_EmployeeId",
                table: "CargoStatusProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CargoStatusProcesses_EmployeeId",
                table: "CargoStatusProcesses");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "CargoStatusProcesses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "CargoStatusProcesses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStatusProcesses_AppUserId",
                table: "CargoStatusProcesses",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoStatusProcesses_AspNetUsers_AppUserId",
                table: "CargoStatusProcesses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
