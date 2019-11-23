using Microsoft.EntityFrameworkCore.Migrations;

namespace turnotucapp.Migrations.AppTurnoTucDb
{
    public partial class SolvedSucMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SucursalID",
                table: "Turnos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialID",
                table: "Sucursals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_SucursalID",
                table: "Turnos",
                column: "SucursalID");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursals_ObraSocialID",
                table: "Sucursals",
                column: "ObraSocialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursals_Obras_ObraSocialID",
                table: "Sucursals",
                column: "ObraSocialID",
                principalTable: "Obras",
                principalColumn: "ObraSocialID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Sucursals_SucursalID",
                table: "Turnos",
                column: "SucursalID",
                principalTable: "Sucursals",
                principalColumn: "SucursalID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sucursals_Obras_ObraSocialID",
                table: "Sucursals");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Sucursals_SucursalID",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_SucursalID",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Sucursals_ObraSocialID",
                table: "Sucursals");

            migrationBuilder.DropColumn(
                name: "SucursalID",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ObraSocialID",
                table: "Sucursals");
        }
    }
}
