using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class factoryRegisterSuppliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 1, "Categoria 1", "Fornecedor 1" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 2, "Categoria 2", "Fornecedor 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
