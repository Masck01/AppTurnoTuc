using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace turnotucapp.Migrations.AppTurnoTucDb
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObraSocialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Cuit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraSocialID);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteID);
                });

            migrationBuilder.CreateTable(
                name: "Sucursals",
                columns: table => new
                {
                    SucursalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSucursal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursals", x => x.SucursalID);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    PacienteID = table.Column<int>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoID);
                    table.ForeignKey(
                        name: "FK_Turnos_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atencions",
                columns: table => new
                {
                    BocaDeAtencionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeAtencion = table.Column<int>(nullable: false),
                    TipoAtencion = table.Column<string>(nullable: true),
                    DescripcionAtencion = table.Column<string>(nullable: true),
                    SucursalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atencions", x => x.BocaDeAtencionID);
                    table.ForeignKey(
                        name: "FK_Atencions_Sucursals_SucursalID",
                        column: x => x.SucursalID,
                        principalTable: "Sucursals",
                        principalColumn: "SucursalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_SucursalID",
                table: "Atencions",
                column: "SucursalID");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacienteID",
                table: "Turnos",
                column: "PacienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atencions");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Sucursals");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
