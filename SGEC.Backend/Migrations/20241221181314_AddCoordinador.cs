using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGEC.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCoordinador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coordinadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coordinadors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coordinadors_Nombre",
                table: "coordinadors",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coordinadors");
        }
    }
}
