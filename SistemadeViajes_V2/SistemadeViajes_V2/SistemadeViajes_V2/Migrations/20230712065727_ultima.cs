using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemadeViajes_V2.Migrations
{
    /// <inheritdoc />
    public partial class ultima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "sucursales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "colaborador",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idcolaborador = table.Column<int>(type: "int", nullable: false),
                    colaboradorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_colaborador_colaboradorid",
                        column: x => x.colaboradorid,
                        principalTable: "colaborador",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaViaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    Transportista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distancia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "colaborador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viajes_sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "sucursales",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_colaboradorid",
                table: "Users",
                column: "colaboradorid");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ColaboradorId",
                table: "Viajes",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_SucursalId",
                table: "Viajes",
                column: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "colaborador");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "sucursales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "colaborador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
