using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemadeViajes_V2.Migrations
{
    /// <inheritdoc />
    public partial class sucursales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "casa",
                table: "colaborador",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "sucursales",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distancia = table.Column<double>(type: "float", nullable: false),
                    idcolaborador = table.Column<int>(type: "int", nullable: false),
                    colaboradorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sucursales", x => x.IdSucursal);
                    table.ForeignKey(
                        name: "FK_sucursales_colaborador_colaboradorid",
                        column: x => x.colaboradorid,
                        principalTable: "colaborador",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sucursales_colaboradorid",
                table: "sucursales",
                column: "colaboradorid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sucursales");

            migrationBuilder.DropColumn(
                name: "casa",
                table: "colaborador");
        }
    }
}
