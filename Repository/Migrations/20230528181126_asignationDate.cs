using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class asignationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*/
             
             migrationBuilder.DropForeignKey(
                name: "FK_Personas_Aareas_idArea",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Aareas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_idArea",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "idArea",
                table: "Personas");
             */

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAsignacion",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrega",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAsignacion",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FechaEntrega",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "idArea",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aareas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
