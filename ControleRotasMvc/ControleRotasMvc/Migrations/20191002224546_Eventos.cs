using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class Eventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {          
            migrationBuilder.RenameColumn(
                name: "NomeAluno",
                table: "Eventos",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Inicio",
                table: "Eventos",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "Fim",
                table: "Eventos",
                newName: "Cor");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsFullDay",
                table: "Eventos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "IsFullDay",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Eventos");


            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Eventos",
                newName: "NomeAluno");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Eventos",
                newName: "Inicio");

            migrationBuilder.RenameColumn(
                name: "Cor",
                table: "Eventos",
                newName: "Fim");
        }
    }
}
