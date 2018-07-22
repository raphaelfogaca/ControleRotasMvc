using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class Financeiro2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensalidades_Alunos_AlunoId",
                table: "DocumentoFinanceiro");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "DocumentoFinanceiro",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensalidades_Alunos_AlunoId",
                table: "DocumentoFinanceiro",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensalidades_Alunos_AlunoId",
                table: "DocumentoFinanceiro");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "DocumentoFinanceiro",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Mensalidades_Alunos_AlunoId",
                table: "DocumentoFinanceiro",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
