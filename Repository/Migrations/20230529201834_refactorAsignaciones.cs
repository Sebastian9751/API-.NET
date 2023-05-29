using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactorAsignaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaciones_Items_id_activo",
                table: "Asignaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Asignaciones_Personas_id_empleoyee",
                table: "Asignaciones");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "Asignaciones",
                newName: "dia_liberacion");

            migrationBuilder.RenameColumn(
                name: "id_empleoyee",
                table: "Asignaciones",
                newName: "id_persona");

            migrationBuilder.RenameColumn(
                name: "id_activo",
                table: "Asignaciones",
                newName: "id_item");

            migrationBuilder.RenameColumn(
                name: "delivery_date",
                table: "Asignaciones",
                newName: "dia_entrega");

            migrationBuilder.RenameColumn(
                name: "assignment_date",
                table: "Asignaciones",
                newName: "dia_asignacion");

            migrationBuilder.RenameIndex(
                name: "IX_Asignaciones_id_empleoyee",
                table: "Asignaciones",
                newName: "IX_Asignaciones_id_persona");

            migrationBuilder.RenameIndex(
                name: "IX_Asignaciones_id_activo",
                table: "Asignaciones",
                newName: "IX_Asignaciones_id_item");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaciones_Items_id_item",
                table: "Asignaciones",
                column: "id_item",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaciones_Personas_id_persona",
                table: "Asignaciones",
                column: "id_persona",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaciones_Items_id_item",
                table: "Asignaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Asignaciones_Personas_id_persona",
                table: "Asignaciones");

            migrationBuilder.RenameColumn(
                name: "id_persona",
                table: "Asignaciones",
                newName: "id_empleoyee");

            migrationBuilder.RenameColumn(
                name: "id_item",
                table: "Asignaciones",
                newName: "id_activo");

            migrationBuilder.RenameColumn(
                name: "dia_liberacion",
                table: "Asignaciones",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "dia_entrega",
                table: "Asignaciones",
                newName: "delivery_date");

            migrationBuilder.RenameColumn(
                name: "dia_asignacion",
                table: "Asignaciones",
                newName: "assignment_date");

            migrationBuilder.RenameIndex(
                name: "IX_Asignaciones_id_persona",
                table: "Asignaciones",
                newName: "IX_Asignaciones_id_empleoyee");

            migrationBuilder.RenameIndex(
                name: "IX_Asignaciones_id_item",
                table: "Asignaciones",
                newName: "IX_Asignaciones_id_activo");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaciones_Items_id_activo",
                table: "Asignaciones",
                column: "id_activo",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaciones_Personas_id_empleoyee",
                table: "Asignaciones",
                column: "id_empleoyee",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
