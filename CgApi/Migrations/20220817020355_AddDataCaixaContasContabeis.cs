using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CgApi.Migrations
{
    public partial class AddDataCaixaContasContabeis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCaixa",
                table: "Tb_Contas_Contabeis",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCaixa",
                table: "Tb_Contas_Contabeis");
        }
    }
}
