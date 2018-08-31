using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class Notas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_MateriaAlunos_MateriaAlunosIdId",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "MateriaAlunosIdId",
                table: "Notas",
                newName: "MateriaAlunosId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_MateriaAlunosIdId",
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
                newName: "MateriaAlunosIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_MateriaAlunosId",
                table: "Notas",
                newName: "IX_Notas_MateriaAlunosIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_MateriaAlunos_MateriaAlunosIdId",
                table: "Notas",
                column: "MateriaAlunosIdId",
                principalTable: "MateriaAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
