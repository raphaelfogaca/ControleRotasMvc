using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleRotasMvc.Migrations
{
    public partial class Boletos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoletoBarcode",
                table: "DocumentosFinanceiros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoletoCode",
                table: "DocumentosFinanceiros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoletoPaymentLink",
                table: "DocumentosFinanceiros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoletoVencimento",
                table: "DocumentosFinanceiros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
