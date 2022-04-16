using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Infra.Data.Migrations
{
    public partial class AddUniqueIndexToCityNameAndUf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Example",
                schema: "dbo",
                newName: "Example");

            migrationBuilder.CreateIndex(
                name: "IX_City_Name_Uf",
                table: "City",
                columns: new[] { "Name", "Uf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_City_Name_Uf",
                table: "City");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Example",
                newName: "Example",
                newSchema: "dbo");
        }
    }
}
