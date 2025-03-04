using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSeguros.Migrations
{
    /// <inheritdoc />
    public partial class TablaClientes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Rtn = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    CodCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FecNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    TipoPersona = table.Column<int>(type: "int", nullable: false),
                    celular = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FecRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
