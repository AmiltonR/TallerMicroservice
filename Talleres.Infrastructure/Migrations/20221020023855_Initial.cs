using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talleres.Infrastructure.Migrations
{
    public partial class Initial : Migration
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
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrocinadores",
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
                    table.PrimaryKey("PK_Patrocinadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdadMinima = table.Column<int>(type: "int", nullable: false),
                    EdadMaxima = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicos", x => x.Id);
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
                name: "TallerProgramaciones",
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
                    table.PrimaryKey("PK_TallerProgramaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerProgramaciones_Patrocinadores_IdPatrocinador",
                        column: x => x.IdPatrocinador,
                        principalTable: "Patrocinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallerProgramaciones_Publicos_IdPublico",
                        column: x => x.IdPublico,
                        principalTable: "Publicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallerProgramaciones_Talleres_IdTaller",
                        column: x => x.IdTaller,
                        principalTable: "Talleres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTallerProgramacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_TallerProgramaciones_IdTallerProgramacion",
                        column: x => x.IdTallerProgramacion,
                        principalTable: "TallerProgramaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallerAsistencias",
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
                    table.PrimaryKey("PK_TallerAsistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerAsistencias_TallerProgramaciones_IdTallerProgramacion",
                        column: x => x.IdTallerProgramacion,
                        principalTable: "TallerProgramaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallerHorarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTallerProgramacion = table.Column<int>(type: "int", nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallerHorarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerHorarios_Horario_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TallerHorarios_TallerProgramaciones_IdTallerProgramacion",
                        column: x => x.IdTallerProgramacion,
                        principalTable: "TallerProgramaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TallerParticipantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTallerProgramacion = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallerParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TallerParticipantes_TallerProgramaciones_IdTallerProgramacion",
                        column: x => x.IdTallerProgramacion,
                        principalTable: "TallerProgramaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_IdTallerProgramacion",
                table: "Solicitudes",
                column: "IdTallerProgramacion");

            migrationBuilder.CreateIndex(
                name: "IX_TallerAsistencias_IdTallerProgramacion",
                table: "TallerAsistencias",
                column: "IdTallerProgramacion");

            migrationBuilder.CreateIndex(
                name: "IX_TallerHorarios_IdHorario",
                table: "TallerHorarios",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_TallerHorarios_IdTallerProgramacion",
                table: "TallerHorarios",
                column: "IdTallerProgramacion");

            migrationBuilder.CreateIndex(
                name: "IX_TallerParticipantes_IdTallerProgramacion",
                table: "TallerParticipantes",
                column: "IdTallerProgramacion");

            migrationBuilder.CreateIndex(
                name: "IX_TallerProgramaciones_IdPatrocinador",
                table: "TallerProgramaciones",
                column: "IdPatrocinador");

            migrationBuilder.CreateIndex(
                name: "IX_TallerProgramaciones_IdPublico",
                table: "TallerProgramaciones",
                column: "IdPublico");

            migrationBuilder.CreateIndex(
                name: "IX_TallerProgramaciones_IdTaller",
                table: "TallerProgramaciones",
                column: "IdTaller");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "TallerAsistencias");

            migrationBuilder.DropTable(
                name: "TallerHorarios");

            migrationBuilder.DropTable(
                name: "TallerParticipantes");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "TallerProgramaciones");

            migrationBuilder.DropTable(
                name: "Patrocinadores");

            migrationBuilder.DropTable(
                name: "Publicos");

            migrationBuilder.DropTable(
                name: "Talleres");
        }
    }
}
