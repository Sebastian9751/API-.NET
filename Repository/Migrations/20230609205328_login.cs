using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Items_ItemId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_ItemId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Personas");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Personas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Personas");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ItemId",
                table: "Personas",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Items_ItemId",
                table: "Personas",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
