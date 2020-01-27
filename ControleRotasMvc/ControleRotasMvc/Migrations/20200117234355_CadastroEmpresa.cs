using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class CadastroEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Empresas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HabilitarPagSeguro",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReponsavelTelefone",
                table: "Empresas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel",
                table: "Empresas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsavelEmail",
                table: "Empresas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emailPagseguro",
                table: "Empresas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tokenPagSeguro",
                table: "Empresas",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "HabilitarPagSeguro",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ReponsavelTelefone",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Responsavel",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ResponsavelEmail",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "emailPagseguro",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "tokenPagSeguro",
                table: "Empresas");
        }
    }
}
