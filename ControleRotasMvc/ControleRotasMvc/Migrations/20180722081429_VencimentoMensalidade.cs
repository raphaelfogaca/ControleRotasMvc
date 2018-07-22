using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class VencimentoMensalidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensalidades_Alunos_AlunoId",
                table: "DocumentoFinanceiro");

            migrationBuilder.DropIndex(
                name: "IX_Mensalidades_AlunoId",
                table: "DocumentoFinanceiro");

            migrationBuilder.DropColumn(
                name: "Vencimento",
                table: "DocumentoFinanceiro");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Vencimento",
                table: "DocumentoFinanceiro",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidades_AlunoId",
                table: "DocumentoFinanceiro",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensalidades_Alunos_AlunoId",
                table: "DocumentoFinanceiro",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
