namespace indogrosir_tim8.Models
{
    public class PesananProduk
    {
        public int Id { get; set; }
        public string Produk { get; set; }
        public int Jumlah { get; set; }
        public int PesananId { get; set; }
    }
}
