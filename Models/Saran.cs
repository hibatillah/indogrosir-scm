using System.ComponentModel.DataAnnotations;

namespace indogrosir_tim8.Models
{
    public class Saran
    {
        public int Id { get; set; } 
        public string Nama { get; set; }
        public string NoHape { get; set; }
        public string Cabang { get; set; }
        public string Pesan { get; set; }
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }
    }
}
