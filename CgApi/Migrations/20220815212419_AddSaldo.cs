using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CgApi.Migrations
{
    public partial class AddSaldo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Tb_Contas_Contabeis",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Tb_Contas_Contabeis");
        }
    }
}
