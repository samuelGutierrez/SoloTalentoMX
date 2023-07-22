using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoloTalentoMX.Entity.Migrations
{
    /// <inheritdoc />
    public partial class MejorasVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadCompra",
                table: "ClienteArticulo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadCompra",
                table: "ClienteArticulo");
        }
    }
}
