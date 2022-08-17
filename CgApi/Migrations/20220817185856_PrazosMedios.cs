using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CgApi.Migrations
{
    public partial class PrazosMedios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrazoMedioFaturamento",
                table: "Tb_Projeto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrazoMedioRecebimento",
                table: "Tb_Projeto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrazoMedioVendas",
                table: "Tb_Projeto",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrazoMedioFaturamento",
                table: "Tb_Projeto");

            migrationBuilder.DropColumn(
                name: "PrazoMedioRecebimento",
                table: "Tb_Projeto");

            migrationBuilder.DropColumn(
                name: "PrazoMedioVendas",
                table: "Tb_Projeto");
        }
    }
}
