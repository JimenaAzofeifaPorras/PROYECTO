using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class NewTablePiscinav3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piscina",
                columns: table => new
                {
                    PiscinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmpleadoComentario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaHoraComentario = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Piscina__CEB9811974BB9210", x => x.PiscinaId);
                    table.ForeignKey(
                        name: "FK_Piscina_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Piscina_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "idServicio");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piscina_ClienteId",
                table: "Piscina",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Piscina_ServicioId",
                table: "Piscina",
                column: "ServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piscina");
        }
    }
}
