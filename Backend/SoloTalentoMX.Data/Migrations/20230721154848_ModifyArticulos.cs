using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoloTalentoMX.Entity.Migrations
{
    /// <inheritdoc />
    public partial class ModifyArticulos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precion",
                table: "Articulos",
                newName: "Precio");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagen",
                table: "Articulos",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Articulos",
                newName: "Precion");

            migrationBuilder.AlterColumn<string>(
                name: "Imagen",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
