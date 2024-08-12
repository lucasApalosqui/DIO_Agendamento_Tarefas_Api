using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DioAgendamentoTarefasApi.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Tarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tarefa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Tarefa");
        }
    }
}
