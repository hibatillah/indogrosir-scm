using System.ComponentModel.DataAnnotations;

namespace indogrosir_tim8.Models
{
    public class Mitra
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Cabang { get; set; }
        [Display(Name = "Tahun Berdiri")]
        [DataType(DataType.Date)]
        public DateTime TahunBerdiri { get; set; }
        [Display(Name = "Gabung Member")]
        [DataType(DataType.Date)]
        public DateTime GabungMember { get; set; }
        public string Admin { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public string? Produk {  get; set; }
    }
}
