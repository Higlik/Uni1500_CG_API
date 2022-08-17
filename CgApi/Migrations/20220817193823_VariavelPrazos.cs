using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CgApi.Migrations
{
    public partial class VariavelPrazos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCaixa",
                table: "Tb_Projeto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "Tb_Projeto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVenda",
                table: "Tb_Projeto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesCompetente",
                table: "Tb_Projeto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValorMedio",
                table: "Tb_Projeto",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCaixa",
                table: "Tb_Projeto");

            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "Tb_Projeto");

            migrationBuilder.DropColumn(
                name: "DataVenda",
                table: "Tb_Projeto");

            migrationBuilder.DropColumn(
                name: "MesCompetente",
                table: "Tb_Projeto");

            migrationBuilder.DropColumn(
                name: "ValorMedio",
                table: "Tb_Projeto");
        }
    }
}
