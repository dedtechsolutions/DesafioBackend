using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioBack.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "id", "data_atualizacao", "data_criacao", "descricao", "titulo" },
                values: new object[] { 1, null, new DateTime(2022, 9, 1, 11, 42, 54, 386, DateTimeKind.Local).AddTicks(8155), "Teste de Descrição 1", "Titulo 1" });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "id", "data_atualizacao", "data_criacao", "descricao", "titulo" },
                values: new object[] { 2, null, new DateTime(2022, 9, 1, 11, 42, 54, 387, DateTimeKind.Local).AddTicks(8528), "Teste de Descrição 2", "Titulo 2" });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "id", "data_atualizacao", "data_criacao", "descricao", "titulo" },
                values: new object[] { 3, null, new DateTime(2022, 9, 1, 11, 42, 54, 387, DateTimeKind.Local).AddTicks(8547), "Teste de Descrição 3", "Titulo 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
