using System.ComponentModel.DataAnnotations;

namespace indogrosir_tim8.Models
{
    public class Pesanan
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }
        public string Mitra { get; set; }
        public string Cabang { get; set; }
        public string? Admin {  get; set; }
        public string Produk { get; set; }
        [Display(Name = "Total Harga")]
        public decimal TotalHarga { get; set; }
        [Display(Name = "Jumlah Pesanan")]
        public int JumlahPesanan { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }
    }
}
