using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class StatusUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Vencimento",
                table: "Financeiros",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "Vencimento",
                table: "Financeiros",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
