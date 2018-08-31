using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class NotaAlunoMateria3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Materias_MateriaId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "MateriaId",
                table: "Notas",
                newName: "MateriaAlunosId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_MateriaId",
                table: "Notas",
                newName: "IX_Notas_MateriaAlunosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_MateriaAlunos_MateriaAlunosId",
                table: "Notas",
                column: "MateriaAlunosId",
                principalTable: "MateriaAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_MateriaAlunos_MateriaAlunosId",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "MateriaAlunosId",
                table: "Notas",
                newName: "MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_MateriaAlunosId",
                table: "Notas",
                newName: "IX_Notas_MateriaId");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Notas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Materias_MateriaId",
                table: "Notas",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
