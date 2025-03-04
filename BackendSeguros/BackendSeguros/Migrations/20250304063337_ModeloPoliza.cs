using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSeguros.Migrations
{
    /// <inheritdoc />
    public partial class ModeloPoliza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poliza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    corredorId = table.Column<int>(type: "int", nullable: false),
                    ramoId = table.Column<int>(type: "int", nullable: false),
                    montoAsegurar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    montoNeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    impuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliza", x => x.id);
                    table.ForeignKey(
                        name: "FK_Poliza_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poliza_Corredor_corredorId",
                        column: x => x.corredorId,
                        principalTable: "Corredor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poliza_Ramo_ramoId",
                        column: x => x.ramoId,
                        principalTable: "Ramo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_clienteId",
                table: "Poliza",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_corredorId",
                table: "Poliza",
                column: "corredorId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_ramoId",
                table: "Poliza",
                column: "ramoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poliza");
        }
    }
}
