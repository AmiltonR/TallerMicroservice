using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talleres.Infrastructure.Migrations
{
    public partial class ChangingPropertiesToPublico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TallerParticipante_TallerProgramacion_IdTallerProgramacion",
                table: "TallerParticipante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerParticipante",
                table: "TallerParticipante");

            migrationBuilder.DropColumn(
                name: "PublicoObjetivo",
                table: "Publico");

            migrationBuilder.RenameTable(
                name: "TallerParticipante",
                newName: "TallerParticipantes");

            migrationBuilder.RenameIndex(
                name: "IX_TallerParticipante_IdTallerProgramacion",
                table: "TallerParticipantes",
                newName: "IX_TallerParticipantes_IdTallerProgramacion");

            migrationBuilder.AddColumn<int>(
                name: "EdadMaxima",
                table: "Publico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EdadMinima",
                table: "Publico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerParticipantes",
                table: "TallerParticipantes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TallerParticipantes_TallerProgramacion_IdTallerProgramacion",
                table: "TallerParticipantes",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TallerParticipantes_TallerProgramacion_IdTallerProgramacion",
                table: "TallerParticipantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TallerParticipantes",
                table: "TallerParticipantes");

            migrationBuilder.DropColumn(
                name: "EdadMaxima",
                table: "Publico");

            migrationBuilder.DropColumn(
                name: "EdadMinima",
                table: "Publico");

            migrationBuilder.RenameTable(
                name: "TallerParticipantes",
                newName: "TallerParticipante");

            migrationBuilder.RenameIndex(
                name: "IX_TallerParticipantes_IdTallerProgramacion",
                table: "TallerParticipante",
                newName: "IX_TallerParticipante_IdTallerProgramacion");

            migrationBuilder.AddColumn<string>(
                name: "PublicoObjetivo",
                table: "Publico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TallerParticipante",
                table: "TallerParticipante",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TallerParticipante_TallerProgramacion_IdTallerProgramacion",
                table: "TallerParticipante",
                column: "IdTallerProgramacion",
                principalTable: "TallerProgramacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
