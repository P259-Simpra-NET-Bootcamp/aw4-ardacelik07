using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimApi.Data.Migrations
{
    public partial class letter3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "dbo",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "dbo",
                newName: "category",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Category_Name",
                schema: "dbo",
                table: "category",
                newName: "IX_category_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                schema: "dbo",
                table: "category",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                schema: "dbo",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                schema: "dbo",
                newName: "Category",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_category_Name",
                schema: "dbo",
                table: "Category",
                newName: "IX_Category_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "dbo",
                table: "Category",
                column: "Id");
        }
    }
}
