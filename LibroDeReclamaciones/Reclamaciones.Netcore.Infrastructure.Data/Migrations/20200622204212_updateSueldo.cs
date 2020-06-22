using Microsoft.EntityFrameworkCore.Migrations;

namespace Netcore.Infrastructure.Data.Migrations
{
    public partial class updateSueldo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Sueldo",
                table: "Empleado",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Apellido materno de la persona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "Empleado");
        }
    }
}
