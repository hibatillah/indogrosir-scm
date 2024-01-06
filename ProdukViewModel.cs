using System.ComponentModel.DataAnnotations;

namespace indogrosir_tim8
{
    public class ProdukViewModel
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Kategori { get; set; }
        public decimal Harga { get; set; }
        [Display(Name = "Jumlah Stok")]
        public int Jumlah { get; set; }
        [Display(Name = "Minimum Stok")]
        public decimal Minimum { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public IFormFile Gambar { get; set; }
    }
}
