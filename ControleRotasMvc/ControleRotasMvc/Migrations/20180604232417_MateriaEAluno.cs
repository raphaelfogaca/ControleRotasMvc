using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class MateriaEAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MateriaAluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlunoId = table.Column<int>(nullable: true),
                    MateriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaAluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaAluno_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MateriaAluno_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAluno_AlunoId",
                table: "MateriaAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAluno_MateriaId",
                table: "MateriaAluno",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaAluno");

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
    }
}
