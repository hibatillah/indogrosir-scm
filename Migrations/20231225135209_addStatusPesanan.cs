using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indogrosir_tim8.Migrations
{
    /// <inheritdoc />
    public partial class addStatusPesanan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Pesanan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pesanan");
        }
    }
}
