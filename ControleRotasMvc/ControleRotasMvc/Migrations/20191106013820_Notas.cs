using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class Notas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "Bimestre",
                table: "Notas",
                newName: "Bimestre4");

            migrationBuilder.AddColumn<int>(
                name: "Bimestre1",
                table: "Notas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Bimestre2",
                table: "Notas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Bimestre3",
                table: "Notas",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bimestre1",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Bimestre2",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Bimestre3",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "Bimestre4",
                table: "Notas",
                newName: "Bimestre");
        }
    }
}
