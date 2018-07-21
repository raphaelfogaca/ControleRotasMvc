using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class AlterarClasseMateriaAluno2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAluno_Alunos_AlunoIdId",
                table: "MateriaAluno");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAluno_Materias_MateriaIdId",
                table: "MateriaAluno");

            migrationBuilder.RenameColumn(
                name: "MateriaIdId",
                table: "MateriaAluno",
                newName: "MateriaId");

            migrationBuilder.RenameColumn(
                name: "AlunoIdId",
                table: "MateriaAluno",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAluno_MateriaIdId",
                table: "MateriaAluno",
                newName: "IX_MateriaAluno_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAluno_AlunoIdId",
                table: "MateriaAluno",
                newName: "IX_MateriaAluno_AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAluno_Alunos_AlunoId",
                table: "MateriaAluno",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAluno_Materias_MateriaId",
                table: "MateriaAluno",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAluno_Alunos_AlunoId",
                table: "MateriaAluno");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAluno_Materias_MateriaId",
                table: "MateriaAluno");

            migrationBuilder.RenameColumn(
                name: "MateriaId",
                table: "MateriaAluno",
                newName: "MateriaIdId");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "MateriaAluno",
                newName: "AlunoIdId");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAluno_MateriaId",
                table: "MateriaAluno",
                newName: "IX_MateriaAluno_MateriaIdId");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAluno_AlunoId",
                table: "MateriaAluno",
                newName: "IX_MateriaAluno_AlunoIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAluno_Alunos_AlunoIdId",
                table: "MateriaAluno",
                column: "AlunoIdId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAluno_Materias_MateriaIdId",
                table: "MateriaAluno",
                column: "MateriaIdId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
