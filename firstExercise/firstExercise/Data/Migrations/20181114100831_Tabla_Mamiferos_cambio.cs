using Microsoft.EntityFrameworkCore.Migrations;

namespace firstExercise.Data.Migrations
{
    public partial class Tabla_Mamiferos_cambio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ecolocalizacion",
                table: "Mamiferos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ecolocalizacion",
                table: "Mamiferos",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
