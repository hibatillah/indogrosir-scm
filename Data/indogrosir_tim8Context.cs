using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using indogrosir_tim8.Models;

namespace indogrosir_tim8.Data
{
    public class indogrosir_tim8Context : DbContext
    {
        public indogrosir_tim8Context (DbContextOptions<indogrosir_tim8Context> options)
            : base(options)
        {
        }

        public DbSet<indogrosir_tim8.Models.Pesanan> Pesanan { get; set; } = default!;

        public DbSet<indogrosir_tim8.Models.Mitra> Mitra { get; set; } = default!;

        public DbSet<indogrosir_tim8.Models.Produk> Produk { get; set; } = default!;

        public DbSet<indogrosir_tim8.Models.Cabang> Cabang { get; set; } = default!;

        public DbSet<indogrosir_tim8.Models.Admin> Admin { get; set; } = default!;
    }
}
