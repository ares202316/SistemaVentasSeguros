using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSeguros.Migrations
{
    /// <inheritdoc />
    public partial class UpPoliza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poliza_Cliente_clienteId",
                table: "Poliza");

            migrationBuilder.DropForeignKey(
                name: "FK_Poliza_Corredor_corredorId",
                table: "Poliza");

            migrationBuilder.DropForeignKey(
                name: "FK_Poliza_Ramo_ramoId",
                table: "Poliza");

            migrationBuilder.AddColumn<DateTime>(
                name: "FecRegistro",
                table: "Poliza",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Poliza_Cliente_clienteId",
                table: "Poliza",
                column: "clienteId",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poliza_Corredor_corredorId",
                table: "Poliza",
                column: "corredorId",
                principalTable: "Corredor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Poliza_Ramo_ramoId",
                table: "Poliza",
                column: "ramoId",
                principalTable: "Ramo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poliza_Cliente_clienteId",
                table: "Poliza");

            migrationBuilder.DropForeignKey(
                name: "FK_Poliza_Corredor_corredorId",
                table: "Poliza");

            migrationBuilder.DropForeignKey(
                name: "FK_Poliza_Ramo_ramoId",
                table: "Poliza");

            migrationBuilder.DropColumn(
                name: "FecRegistro",
                table: "Poliza");

            migrationBuilder.AddForeignKey(
                name: "FK_Poliza_Cliente_clienteId",
                table: "Poliza",
                column: "clienteId",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poliza_Corredor_corredorId",
                table: "Poliza",
                column: "corredorId",
                principalTable: "Corredor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poliza_Ramo_ramoId",
                table: "Poliza",
                column: "ramoId",
                principalTable: "Ramo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
