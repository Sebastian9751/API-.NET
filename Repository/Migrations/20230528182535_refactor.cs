using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumEmpleado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "nombreEmpleado",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "numero_empleado",
                table: "Personas",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numero_empleado",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "NumEmpleado",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreEmpleado",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
