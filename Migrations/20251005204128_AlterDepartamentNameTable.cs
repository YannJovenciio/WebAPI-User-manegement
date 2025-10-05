using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AlterDepartamentNameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Departaments",
                table: "Departaments");

            migrationBuilder.RenameTable(
                name: "Departaments",
                newName: "Departament");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departament",
                table: "Departament",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Departament",
                table: "Departament");

            migrationBuilder.RenameTable(
                name: "Departament",
                newName: "Departaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departaments",
                table: "Departaments",
                column: "Id");
        }
    }
}
