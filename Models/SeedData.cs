using indogrosir_tim8.Data;
using Microsoft.EntityFrameworkCore;

namespace indogrosir_tim8.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new indogrosir_tim8Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<indogrosir_tim8Context>>()))
            {
                // Mitra
                if (context.Mitra.Any() || context.Cabang.Any())
                {
                    return; // DB has been seeded
                }

                context.Mitra.AddRange(
                    new Mitra
                    {
                        Nama = "Ucup Mart",
                        Alamat = "Jl. Tegal Sari, Rumbai",
                        TahunBerdiri = DateTime.Parse("2016-2-12"),
                        GabungMember = DateTime.Parse("2021-2-12"),
                        Cabang = "Pekanbaru",
                        Admin = "Ucup",
                        Email = "ucup@gmail.com",
                        Password = "12345",
                        Produk = "Golda",
                    }
                );

                context.Cabang.AddRange(
                    new Cabang
                    {
                        Nama = "Indogrosir Pekanbaru",
                        Lokasi = "Jalan Soekarno Hatta (Arengka) No.18 RT.01 RW.08, Kel. Sidomulya Barat,Kec. Tampan, Kota Pekanbaru 28294",
                        NoHp = "0761 - 564 641",
                        Gambar = "pekanbaru.png",
                        Admin = "farhan",
                        Gmaps = "http://www.google.com/maps/place/0.4513638,101.4173618"
                    },
                    new Cabang
                    {
                        Nama = "Indogrosir Bandung",
                        Lokasi = "Jalan Ahmad Yani No. 806 (100 M Barat Terminal Cicaheum) Cicaheum Bandung 40282",
                        NoHp = "022-7202711",
                        Gambar = "bandung.png",
                        Admin = "farhan",
                        Gmaps = "http://www.google.com/maps/place/-6.903677,107.654857"
                    },
                    new Cabang
                    {
                        Nama = "Indogrosir Banjarmasin",
                        Lokasi = "Jalan A. Yani Km. 12,200 Kelurahan Gambut Barat , Kecamatan Gambut, Kabupaten Banjar Kalimantan Selatan 70652",
                        NoHp = "022-7202711",
                        Gambar = "banjarmasin.png",
                        Admin = "farhan",
                        Gmaps = "http://www.google.com/maps/place/-3.39262286,114.65804739"
                    },
                    new Cabang
                    {
                        Nama = "Indogrosir Kendari",
                        Lokasi = "Jalan Madusila Kelurahan Anduonohu Kecamatan Poasia Kota Kendari Sulawesi Tenggara",
                        NoHp = "0401-3083025",
                        Gambar = "kendari.png",
                        Admin = "farhan",
                        Gmaps = "http://www.google.com/maps/place/-3.9943811,122.5429033"
                    },
                    new Cabang
                    {
                        Nama = "Indogrosir Ambon",
                        Lokasi = "Jalan Syaranamual Desa Hunuth atau Kate-kate Kecamatan Pulau Ambon Kota Ambon Provinsi Maluku",
                        NoHp = "0911 - 368 5555",
                        Gambar = "ambon.png",
                        Admin = "farhan",
                        Gmaps = "http://www.google.com/maps/place/-3.637003468103064,128.2029516040826"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
