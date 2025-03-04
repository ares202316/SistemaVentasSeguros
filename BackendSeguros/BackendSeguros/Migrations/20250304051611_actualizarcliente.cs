using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSeguros.Migrations
{
    /// <inheritdoc />
    public partial class actualizarcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
