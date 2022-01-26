using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfProject.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeCompleto = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    FotoUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    WhatsApp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Biografia = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorDias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DiaSemana = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HoraDispInicio = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HoraDispFim = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorDias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorDias_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorMaterias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MateriaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustoHora = table.Column<decimal>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorMaterias_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorMaterias_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorDias_ProfessorId",
                table: "ProfessorDias",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorMaterias_MateriaId",
                table: "ProfessorMaterias",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorMaterias_ProfessorId",
                table: "ProfessorMaterias",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorDias");

            migrationBuilder.DropTable(
                name: "ProfessorMaterias");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
