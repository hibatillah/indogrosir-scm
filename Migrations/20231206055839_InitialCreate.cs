using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indogrosir_tim8.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pesanan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mitra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cabang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Produk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalHarga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JumlahPesanan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesanan", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pesanan");
        }
    }
}
