using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSeguros.Migrations
{
    /// <inheritdoc />
    public partial class updatedeCobertura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobertura_Ramo_ramoId",
                table: "Cobertura");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Cobertura",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<double>(
                name: "Deducible",
                table: "Cobertura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobertura_Ramo_ramoId",
                table: "Cobertura",
                column: "ramoId",
                principalTable: "Ramo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobertura_Ramo_ramoId",
                table: "Cobertura");

            migrationBuilder.DropColumn(
                name: "Deducible",
                table: "Cobertura");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Cobertura",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobertura_Ramo_ramoId",
                table: "Cobertura",
                column: "ramoId",
                principalTable: "Ramo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
