using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class tableAsignaciones2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_empleoyee = table.Column<int>(type: "int", nullable: false),
                    id_activo = table.Column<int>(type: "int", nullable: false),
                    assignment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Items_id_activo",
                        column: x => x.id_activo,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Personas_id_empleoyee",
                        column: x => x.id_empleoyee,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_id_activo",
                table: "Asignaciones",
                column: "id_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_id_empleoyee",
                table: "Asignaciones",
                column: "id_empleoyee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones");
        }
    }
}
