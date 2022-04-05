using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketParcial.Migrations.TicketTurno
{
    public partial class modelosticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsuntosList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsuntosList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MunicipiosList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipiosList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NivelesList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelesList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TicketTurnoList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRealiza = table.Column<string>(nullable: false),
                    curp = table.Column<string>(nullable: false),
                    nombre = table.Column<string>(nullable: false),
                    paterno = table.Column<string>(nullable: false),
                    materno = table.Column<string>(nullable: true),
                    telefono = table.Column<int>(nullable: false),
                    celular = table.Column<int>(nullable: false),
                    correo = table.Column<string>(nullable: true),
                    asuntoID = table.Column<int>(nullable: true),
                    municipioID = table.Column<int>(nullable: true),
                    nivelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTurnoList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TicketTurnoList_AsuntosList_asuntoID",
                        column: x => x.asuntoID,
                        principalTable: "AsuntosList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketTurnoList_MunicipiosList_municipioID",
                        column: x => x.municipioID,
                        principalTable: "MunicipiosList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketTurnoList_NivelesList_nivelID",
                        column: x => x.nivelID,
                        principalTable: "NivelesList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTurnoList_asuntoID",
                table: "TicketTurnoList",
                column: "asuntoID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTurnoList_municipioID",
                table: "TicketTurnoList",
                column: "municipioID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTurnoList_nivelID",
                table: "TicketTurnoList",
                column: "nivelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketTurnoList");

            migrationBuilder.DropTable(
                name: "AsuntosList");

            migrationBuilder.DropTable(
                name: "MunicipiosList");

            migrationBuilder.DropTable(
                name: "NivelesList");
        }
    }
}
