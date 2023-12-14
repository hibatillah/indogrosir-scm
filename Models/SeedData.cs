using indogrosir_tim8.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
                if (context.Mitra.Any())
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
                context.SaveChanges();
            }
        }
    }
}
