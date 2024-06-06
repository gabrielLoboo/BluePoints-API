using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BluePoints_API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioPremio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USUARIO_PREMIO",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PremioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO_PREMIO", x => new { x.UsuarioId, x.PremioId });
                    table.ForeignKey(
                        name: "FK_T_USUARIO_PREMIO_T_PREMIO_PremioId",
                        column: x => x.PremioId,
                        principalTable: "T_PREMIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_USUARIO_PREMIO_T_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "T_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_USUARIO_PREMIO_PremioId",
                table: "T_USUARIO_PREMIO",
                column: "PremioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_USUARIO_PREMIO");
        }
    }
}
