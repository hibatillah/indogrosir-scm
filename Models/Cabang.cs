namespace indogrosir_tim8.Models
{
    public class Cabang
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Lokasi { get; set; }
        public string NoHp { get; set; }
        public string Gambar { get; set; }
        public string Gmaps { get; set; }
        public string Admin { get; set; }
        public string? Produk { get; set; }
        public string? Mitra { get; set; }
    }
}
