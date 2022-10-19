using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talleres.Infrastructure.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TallerAsistencia_TallerProgramacion_IdTallerProgramacion",
                table: "TallerAsistencia");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerHorario_Horario_IdHorario",
                table: "TallerHorario");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerHorario_TallerProgramacion_IdTallerProgramacion",
                table: "TallerHorario");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerParticipantes_TallerProgramacion_IdTallerProgramacion",
                table: "TallerParticipantes");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerProgramacion_Patrocinador_IdPatrocinador",
                table: "TallerProgramacion");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerProgramacion_Publico_IdPublico",
                table: "TallerProgramacion");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerProgramacion_Talleres_IdTaller",
                table: "TallerProgramacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerProgramacion",
                table: "TallerProgramacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerHorario",
                table: "TallerHorario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerAsistencia",
                table: "TallerAsistencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publico",
                table: "Publico");

            migrationBuilder.RenameTable(
                name: "TallerProgramacion",
                newName: "TallerProgramaciones");

            migrationBuilder.RenameTable(
                name: "TallerHorario",
                newName: "TallerHorarios");

            migrationBuilder.RenameTable(
                name: "TallerAsistencia",
                newName: "TallerAsistencias");

            migrationBuilder.RenameTable(
                name: "Publico",
                newName: "Publicos");

            migrationBuilder.RenameIndex(
                name: "IX_TallerProgramacion_IdTaller",
                table: "TallerProgramaciones",
                newName: "IX_TallerProgramaciones_IdTaller");

            migrationBuilder.RenameIndex(
                name: "IX_TallerProgramacion_IdPublico",
                table: "TallerProgramaciones",
                newName: "IX_TallerProgramaciones_IdPublico");

            migrationBuilder.RenameIndex(
                name: "IX_TallerProgramacion_IdPatrocinador",
                table: "TallerProgramaciones",
                newName: "IX_TallerProgramaciones_IdPatrocinador");

            migrationBuilder.RenameIndex(
                name: "IX_TallerHorario_IdTallerProgramacion",
                table: "TallerHorarios",
                newName: "IX_TallerHorarios_IdTallerProgramacion");

            migrationBuilder.RenameIndex(
                name: "IX_TallerHorario_IdHorario",
                table: "TallerHorarios",
                newName: "IX_TallerHorarios_IdHorario");

            migrationBuilder.RenameIndex(
                name: "IX_TallerAsistencia_IdTallerProgramacion",
                table: "TallerAsistencias",
                newName: "IX_TallerAsistencias_IdTallerProgramacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerProgramaciones",
                table: "TallerProgramaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerHorarios",
                table: "TallerHorarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerAsistencias",
                table: "TallerAsistencias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicos",
                table: "Publicos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TallerAsistencias_TallerProgramaciones_IdTallerProgramacion",
                table: "TallerAsistencias",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerHorarios_Horario_IdHorario",
                table: "TallerHorarios",
                column: "IdHorario",
                principalTable: "Horario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerHorarios_TallerProgramaciones_IdTallerProgramacion",
                table: "TallerHorarios",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerParticipantes_TallerProgramaciones_IdTallerProgramacion",
                table: "TallerParticipantes",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerProgramaciones_Patrocinador_IdPatrocinador",
                table: "TallerProgramaciones",
                column: "IdPatrocinador",
                principalTable: "Patrocinador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerProgramaciones_Publicos_IdPublico",
                table: "TallerProgramaciones",
                column: "IdPublico",
                principalTable: "Publicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerProgramaciones_Talleres_IdTaller",
                table: "TallerProgramaciones",
                column: "IdTaller",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TallerAsistencias_TallerProgramaciones_IdTallerProgramacion",
                table: "TallerAsistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerHorarios_Horario_IdHorario",
                table: "TallerHorarios");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerHorarios_TallerProgramaciones_IdTallerProgramacion",
                table: "TallerHorarios");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerParticipantes_TallerProgramaciones_IdTallerProgramacion",
                table: "TallerParticipantes");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerProgramaciones_Patrocinador_IdPatrocinador",
                table: "TallerProgramaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerProgramaciones_Publicos_IdPublico",
                table: "TallerProgramaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_TallerProgramaciones_Talleres_IdTaller",
                table: "TallerProgramaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerProgramaciones",
                table: "TallerProgramaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerHorarios",
                table: "TallerHorarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerAsistencias",
                table: "TallerAsistencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicos",
                table: "Publicos");

            migrationBuilder.RenameTable(
                name: "TallerProgramaciones",
                newName: "TallerProgramacion");

            migrationBuilder.RenameTable(
                name: "TallerHorarios",
                newName: "TallerHorario");

            migrationBuilder.RenameTable(
                name: "TallerAsistencias",
                newName: "TallerAsistencia");

            migrationBuilder.RenameTable(
                name: "Publicos",
                newName: "Publico");

            migrationBuilder.RenameIndex(
                name: "IX_TallerProgramaciones_IdTaller",
                table: "TallerProgramacion",
                newName: "IX_TallerProgramacion_IdTaller");

            migrationBuilder.RenameIndex(
                name: "IX_TallerProgramaciones_IdPublico",
                table: "TallerProgramacion",
                newName: "IX_TallerProgramacion_IdPublico");

            migrationBuilder.RenameIndex(
                name: "IX_TallerProgramaciones_IdPatrocinador",
                table: "TallerProgramacion",
                newName: "IX_TallerProgramacion_IdPatrocinador");

            migrationBuilder.RenameIndex(
                name: "IX_TallerHorarios_IdTallerProgramacion",
                table: "TallerHorario",
                newName: "IX_TallerHorario_IdTallerProgramacion");

            migrationBuilder.RenameIndex(
                name: "IX_TallerHorarios_IdHorario",
                table: "TallerHorario",
                newName: "IX_TallerHorario_IdHorario");

            migrationBuilder.RenameIndex(
                name: "IX_TallerAsistencias_IdTallerProgramacion",
                table: "TallerAsistencia",
                newName: "IX_TallerAsistencia_IdTallerProgramacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerProgramacion",
                table: "TallerProgramacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerHorario",
                table: "TallerHorario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerAsistencia",
                table: "TallerAsistencia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publico",
                table: "Publico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TallerAsistencia_TallerProgramacion_IdTallerProgramacion",
                table: "TallerAsistencia",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerHorario_Horario_IdHorario",
                table: "TallerHorario",
                column: "IdHorario",
                principalTable: "Horario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerHorario_TallerProgramacion_IdTallerProgramacion",
                table: "TallerHorario",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerParticipantes_TallerProgramacion_IdTallerProgramacion",
                table: "TallerParticipantes",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerProgramacion_Patrocinador_IdPatrocinador",
                table: "TallerProgramacion",
                column: "IdPatrocinador",
                principalTable: "Patrocinador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerProgramacion_Publico_IdPublico",
                table: "TallerProgramacion",
                column: "IdPublico",
                principalTable: "Publico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TallerProgramacion_Talleres_IdTaller",
                table: "TallerProgramacion",
                column: "IdTaller",
                principalTable: "Talleres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
