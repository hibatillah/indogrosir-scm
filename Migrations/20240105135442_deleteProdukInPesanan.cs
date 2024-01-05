using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indogrosir_tim8.Migrations
{
    /// <inheritdoc />
    public partial class deleteProdukInPesanan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Produk",
                table: "Pesanan");
        }
    }
}
