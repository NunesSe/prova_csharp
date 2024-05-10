using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace William.Migrations
{
    /// <inheritdoc />
    public partial class Impostos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "impostoFgts",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "impostoInss",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "impostoIrrf",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "salarioBruto",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "salarioLiquido",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "impostoFgts",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "impostoInss",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "impostoIrrf",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "salarioBruto",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "salarioLiquido",
                table: "Folhas");
        }
    }
}
