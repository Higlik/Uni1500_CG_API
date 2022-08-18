using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CgApi.Migrations
{
    public partial class Alteracao_FkEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Tb_Empres__FK_Co__37A5467C",
                table: "Tb_Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Empresa_FK_Contas_Contabeis",
                table: "Tb_Empresa");

            migrationBuilder.AddColumn<int>(
                name: "FkEmpresa",
                table: "Tb_Contas_Contabeis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TbFluxoCaixas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lucro = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Despesas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataCaixa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdContaContabil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFluxoCaixas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbFluxoCaixas_Tb_Contas_Contabeis_IdContaContabil",
                        column: x => x.IdContaContabil,
                        principalTable: "Tb_Contas_Contabeis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Contas_Contabeis_FkEmpresa",
                table: "Tb_Contas_Contabeis",
                column: "FkEmpresa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbFluxoCaixas_IdContaContabil",
                table: "TbFluxoCaixas",
                column: "IdContaContabil");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Contas_Contabeis_Tb_Empresa_FkEmpresa",
                table: "Tb_Contas_Contabeis",
                column: "FkEmpresa",
                principalTable: "Tb_Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Contas_Contabeis_Tb_Empresa_FkEmpresa",
                table: "Tb_Contas_Contabeis");

            migrationBuilder.DropTable(
                name: "TbFluxoCaixas");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Contas_Contabeis_FkEmpresa",
                table: "Tb_Contas_Contabeis");

            migrationBuilder.DropColumn(
                name: "FkEmpresa",
                table: "Tb_Contas_Contabeis");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Empresa_FK_Contas_Contabeis",
                table: "Tb_Empresa",
                column: "FK_Contas_Contabeis");

            migrationBuilder.AddForeignKey(
                name: "FK__Tb_Empres__FK_Co__37A5467C",
                table: "Tb_Empresa",
                column: "FK_Contas_Contabeis",
                principalTable: "Tb_Contas_Contabeis",
                principalColumn: "Id");
        }
    }
}
