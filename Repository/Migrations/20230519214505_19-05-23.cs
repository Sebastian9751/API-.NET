using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _190523 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumEmpleado",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idArea",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreEmpleado",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aareas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aareas", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_idArea",
                table: "Personas",
                column: "idArea");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Aareas_idArea",
                table: "Personas",
                column: "idArea",
                principalTable: "Aareas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Aareas_idArea",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Aareas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_idArea",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumEmpleado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "idArea",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "nombreEmpleado",
                table: "Personas");
        }
    }
}
