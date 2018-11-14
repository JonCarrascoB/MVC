using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace firstExercise.Data.Migrations
{
    public partial class Tabla_Mamiferos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.RenameTable(
                name: "Alumnos",
                newName: "Alumnos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Mamiferos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Patas = table.Column<int>(nullable: false),
                    NombreCientifico = table.Column<string>(nullable: true),
                    Ecolocalizacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mamiferos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mamiferos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.RenameTable(
                name: "Alumnos",
                newName: "Alumnos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumno",
                table: "Alumnos",
                column: "Id");
        }
    }
}
