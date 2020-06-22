using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Netcore.Infrastructure.Data.Migrations
{
    public partial class InitialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", nullable: false, comment: "Nombre de la afp")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", nullable: false, comment: "Nombre del cargo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(64)", nullable: false, comment: "Nombre de la persona"),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(64)", nullable: false, comment: "Apellido paterno de la persona"),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(64)", nullable: false, comment: "Apellido materno de la persona"),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    IdAfp = table.Column<int>(nullable: false),
                    IdCargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Afp_IdAfp",
                        column: x => x.IdAfp,
                        principalTable: "Afp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Empleado_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdAfp",
                table: "Empleado",
                column: "IdAfp");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdCargo",
                table: "Empleado",
                column: "IdCargo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Afp");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
