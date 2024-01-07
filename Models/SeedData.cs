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
                if (context.Cabang.Any() 
                    || context.Admin.Any() || context.Produk.Any() || context.Mitra.Any()
                    )
                {
                    return; // DB has been seeded
                }

                context.Admin.AddRange(
                    new Admin
                    {
                        Nama = "Raul",
                        Email = "raul@gmail.com",
                        Password = "123",
                        Cabang = "Pekanbaru",
                    },
                    new Admin
                    {
                        Nama = "farhan",
                        Email = "farhan@gmail.com",
                        Password = "123",
                        Cabang = "Bandung",
                    }
                );
                context.Mitra.AddRange(
                    new Mitra
                    {
                        Nama = "Siti",
                        Alamat = "Jl. Padat Karya No.11",
                        Cabang = "Pekanbaru",
                        TahunBerdiri = DateTime.Parse("2016-7-23"),
                        GabungMember = DateTime.Parse("2024-1-7"),
                        Admin = "Siti",
                        Email = "siti@gmail.com",
                        Password = "123",
              
                    },
                    new Mitra
                    {
                        Nama = "Budi",
                        Alamat = "Jl.Srikandi No.45",
                        Cabang = "Pekanbaru",
                        TahunBerdiri = DateTime.Parse("2017-3-3"),
                        GabungMember = DateTime.Parse("2024-1-7"),
                        Admin = "Budi",
                        Email = "budi@gmail.com",
                        Password = "123",
                        
                    },
                    new Mitra
                    {
                        Nama = "Andi",
                        Alamat = "Jl. Sukajaya No.33",
                        Cabang = "Bandung",
                        TahunBerdiri = DateTime.Parse("2018-4-29"),
                        GabungMember = DateTime.Parse("2024-1-7"),
                        Admin = "Andi",
                        Email = "andi@gmail.com",
                        Password = "123",
                        
                    }
                );

                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Golda",
                        Kategori = "Minuman",
                        Harga = 3000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId =1,
                        UserRole = "admin",
                        Gambar = "golda.jpg",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Chitato",
                        Kategori = "Makanan Ringan",
                        Harga = 6000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 1,
                        UserRole = "admin",
                        Gambar = "chitato.jpg",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Nescafe",
                        Kategori = "Minuman",
                        Harga = 8000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 2,
                        UserRole = "admin",
                        Gambar = "nescafe.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Qtela",
                        Kategori = "Makana Ringan",
                        Harga = 6000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 2,
                        UserRole = "admin",
                        Gambar = "qtela.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Pucuk",
                        Kategori = "Minuman",
                        Harga = 4000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 1,
                        UserRole = "mitra",
                        Gambar = "pucuk.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Coca-cola",
                        Kategori = "Minuman",
                        Harga = 8000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 1,
                        UserRole = "mitra",
                        Gambar = "coca-cola.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Redbull",
                        Kategori = "Minuman",
                        Harga = 24000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 1,
                        UserRole = "mitra",
                        Gambar = "redbull.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Teh Botol",
                        Kategori = "Minuman",
                        Harga = 10000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 2,
                        UserRole = "mitra",
                        Gambar = "tehbotol.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Freshtea",
                        Kategori = "Minuman",
                        Harga = 10000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 2,
                        UserRole = "mitra",
                        Gambar = "freshtea.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Sprite",
                        Kategori = "Minuman",
                        Harga = 10000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 2,
                        UserRole = "mitra",
                        Gambar = "sprite.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Popmie",
                        Kategori = "Makanan",
                        Harga = 5000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 3,
                        UserRole = "mitra",
                        Gambar = "popmie.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Indomie",
                        Kategori = "Minuman",
                        Harga = 3000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 3,
                        UserRole = "mitra",
                        Gambar = "indomie.png",
                    }

                );
                context.Produk.AddRange(
                    new Produk
                    {
                        Nama = "Aqua",
                        Kategori = "Minuman",
                        Harga = 5000,
                        Jumlah = 10,
                        Minimum = 100,
                        UserId = 3,
                        UserRole = "mitra",
                        Gambar = "aqua.png",
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
