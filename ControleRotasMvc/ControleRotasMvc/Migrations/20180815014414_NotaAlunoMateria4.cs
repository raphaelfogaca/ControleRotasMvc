﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class NotaAlunoMateria4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_MateriaAlunos_MateriaAlunosId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_MateriaAlunosId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "MateriaAlunosId",
                table: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Notas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Notas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlunoId",
                table: "Notas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaId",
                table: "Notas",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Alunos_AlunoId",
                table: "Notas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Materias_MateriaId",
                table: "Notas",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Notas_MateriaId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "MateriaAlunosId",
                table: "Notas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaAlunosId",
                table: "Notas",
                column: "MateriaAlunosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_MateriaAlunos_MateriaAlunosId",
                table: "Notas",
                column: "MateriaAlunosId",
                principalTable: "MateriaAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
