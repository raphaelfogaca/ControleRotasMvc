using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class VencimentoMensalidadeInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vencimento",
                table: "DocumentoFinanceiro",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vencimento",
                table: "DocumentoFinanceiro");
        }
    }
}
