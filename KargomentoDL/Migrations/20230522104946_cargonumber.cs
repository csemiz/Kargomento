using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargomentoDL.Migrations
{
    /// <inheritdoc />
    public partial class cargonumber : Migration
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
                oldType: "nvarchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Cargos",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CargoId",
                table: "CargoStatusProcesses",
                type: "nvarchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Cargos",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);
        }
    }
}
