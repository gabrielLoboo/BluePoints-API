using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BluePoints_API.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "T_PREMIO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "T_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_PREMIO_CategoriaId",
                table: "T_PREMIO",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_PREMIO_T_CATEGORIA_CategoriaId",
                table: "T_PREMIO",
                column: "CategoriaId",
                principalTable: "T_CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_PREMIO_T_CATEGORIA_CategoriaId",
                table: "T_PREMIO");

            migrationBuilder.DropTable(
                name: "T_CATEGORIA");

            migrationBuilder.DropIndex(
                name: "IX_T_PREMIO_CategoriaId",
                table: "T_PREMIO");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "T_PREMIO");
        }
    }
}
