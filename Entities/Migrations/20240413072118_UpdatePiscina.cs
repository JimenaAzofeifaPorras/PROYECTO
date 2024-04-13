using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePiscina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpleadoComentario",
                table: "Piscina");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Piscina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Piscina_EmpleadoId",
                table: "Piscina",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Piscina_Empleado_EmpleadoId",
                table: "Piscina",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "idEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piscina_Empleado_EmpleadoId",
                table: "Piscina");

            migrationBuilder.DropIndex(
                name: "IX_Piscina_EmpleadoId",
                table: "Piscina");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Piscina");

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoComentario",
                table: "Piscina",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
