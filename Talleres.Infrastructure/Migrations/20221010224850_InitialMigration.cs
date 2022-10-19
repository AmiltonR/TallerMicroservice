using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talleres.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFinal = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrocinador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePatrocinador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrocinador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicoObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talleres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTaller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TallerProgramacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTaller = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioInstructor = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroParticipantes = table.Column<int>(type: "int", nullable: false),
                    IdPublico = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    IdPatrocinador = table.Column<int>(type: "int", nullable: false),
                    NumeroSesiones = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallerProgramacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerProgramacion_Patrocinador_IdPatrocinador",
                        column: x => x.IdPatrocinador,
                        principalTable: "Patrocinador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallerProgramacion_Publico_IdPublico",
                        column: x => x.IdPublico,
                        principalTable: "Publico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallerProgramacion_Talleres_IdTaller",
                        column: x => x.IdTaller,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallerAsistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTallerProgramacion = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NumeroSesion = table.Column<int>(type: "int", nullable: false),
                    Asistencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallerAsistencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerAsistencia_TallerProgramacion_IdTallerProgramacion",
                        column: x => x.IdTallerProgramacion,
                        principalTable: "TallerProgramacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallerHorario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTallerProgramacion = table.Column<int>(type: "int", nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallerHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerHorario_Horario_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallerHorario_TallerProgramacion_IdTallerProgramacion",
                        column: x => x.IdTallerProgramacion,
                        principalTable: "TallerProgramacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallerParticipante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTallerProgramacion = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallerParticipante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerParticipante_TallerProgramacion_IdTallerProgramacion",
                        column: x => x.IdTallerProgramacion,
                        principalTable: "TallerProgramacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TallerAsistencia_IdTallerProgramacion",
                table: "TallerAsistencia",
                column: "IdTallerProgramacion");

            migrationBuilder.CreateIndex(
                name: "IX_TallerHorario_IdHorario",
                table: "TallerHorario",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_TallerHorario_IdTallerProgramacion",
                table: "TallerHorario",
                column: "IdTallerProgramacion");

            migrationBuilder.CreateIndex(
                name: "IX_TallerParticipante_IdTallerProgramacion",
                table: "TallerParticipante",
                column: "IdTallerProgramacion");

            migrationBuilder.CreateIndex(
                name: "IX_TallerProgramacion_IdPatrocinador",
                table: "TallerProgramacion",
                column: "IdPatrocinador");

            migrationBuilder.CreateIndex(
                name: "IX_TallerProgramacion_IdPublico",
                table: "TallerProgramacion",
                column: "IdPublico");

            migrationBuilder.CreateIndex(
                name: "IX_TallerProgramacion_IdTaller",
                table: "TallerProgramacion",
                column: "IdTaller");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TallerAsistencia");

            migrationBuilder.DropTable(
                name: "TallerHorario");

            migrationBuilder.DropTable(
                name: "TallerParticipante");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "TallerProgramacion");

            migrationBuilder.DropTable(
                name: "Patrocinador");

            migrationBuilder.DropTable(
                name: "Publico");

            migrationBuilder.DropTable(
                name: "Talleres");
        }
    }
}
