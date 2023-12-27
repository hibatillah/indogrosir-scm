using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indogrosir_tim8.Migrations
{
    /// <inheritdoc />
    public partial class updatePesananModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Pesanan");

            migrationBuilder.DropColumn(
                name: "Produk",
                table: "Mitra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Pesanan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Produk",
                table: "Mitra",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
