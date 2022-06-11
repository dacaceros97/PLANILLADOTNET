using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDPLANILLA.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planilla",
                columns: table => new
                {
                    Id_Registro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    IGSS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IRTRA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalarioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalarioLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planilla", x => x.Id_Registro);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoDPI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonoDecreto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "HijoEmpleados",
                columns: table => new
                {
                    Id_Registro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantHijos = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HijoEmpleados", x => x.Id_Registro);
                    table.ForeignKey(
                        name: "FK_HijoEmpleados_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HijoEmpleados_UsuarioIdUsuario",
                table: "HijoEmpleados",
                column: "UsuarioIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HijoEmpleados");

            migrationBuilder.DropTable(
                name: "Planilla");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
