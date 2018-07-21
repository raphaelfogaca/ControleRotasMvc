using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class MateriaAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_MateriaId",
                table: "Alunos",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Materias_MateriaId",
                table: "Alunos",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Materias_MateriaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_MateriaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Alunos");
        }
    }
}
