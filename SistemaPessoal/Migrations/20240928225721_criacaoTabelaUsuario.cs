using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
// arquivo criado altomaticamente atraves dos comandos Add-Migration criacaoTabelaUsuario -Context ApplicationDbContext no console de gerenciamento de pacotes
// pois aqui cria tosas as tabelas no BD, e com o comando Update-Database -Context ApplicationDbContext atualiza o BD com as tabela criadas altomaticamente,

namespace SistemaPessoal.Migrations
{
    public partial class criacaoTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas_Bancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Da_Conta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo_Inicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_Bancarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DespesasModel",
                columns: table => new
                {
                    DespesaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Despesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasModel", x => x.DespesaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "varchar(14)", nullable: false),
                    ConfSenha = table.Column<string>(type: "varchar(14)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualização = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas_Bancarias");

            migrationBuilder.DropTable(
                name: "DespesasModel");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
