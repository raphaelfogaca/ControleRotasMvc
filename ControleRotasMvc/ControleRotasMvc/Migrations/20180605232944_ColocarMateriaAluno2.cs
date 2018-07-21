using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class ColocarMateriaAluno2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAluno_Alunos_AlunoId",
                table: "MateriaAluno");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAluno_Materias_MateriaId",
                table: "MateriaAluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MateriaAluno",
                table: "MateriaAluno");

            migrationBuilder.RenameTable(
                name: "MateriaAluno",
                newName: "MateriaAlunos");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAluno_MateriaId",
                table: "MateriaAlunos",
                newName: "IX_MateriaAlunos_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAluno_AlunoId",
                table: "MateriaAlunos",
                newName: "IX_MateriaAlunos_AlunoId");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "MateriaAlunos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "MateriaAlunos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MateriaAlunos",
                table: "MateriaAlunos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAlunos_Alunos_AlunoId",
                table: "MateriaAlunos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAlunos_Materias_MateriaId",
                table: "MateriaAlunos",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAlunos_Alunos_AlunoId",
                table: "MateriaAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAlunos_Materias_MateriaId",
                table: "MateriaAlunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MateriaAlunos",
                table: "MateriaAlunos");

            migrationBuilder.RenameTable(
                name: "MateriaAlunos",
                newName: "MateriaAluno");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAlunos_MateriaId",
                table: "MateriaAluno",
                newName: "IX_MateriaAluno_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAlunos_AlunoId",
                table: "MateriaAluno",
                newName: "IX_MateriaAluno_AlunoId");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "MateriaAluno",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "MateriaAluno",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MateriaAluno",
                table: "MateriaAluno",
                column: "Id");

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
    }
}
