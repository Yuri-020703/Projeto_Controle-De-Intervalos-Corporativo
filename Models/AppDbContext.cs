using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Controle_de_Intervalos_Corporativo.Models;


namespace Controle_de_Intervalos_Corporativo.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Intervalo> Intervalos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.GetFullPath("IntervalosCorporativos.db");
            //Console.WriteLine($"[DEBUG] Usando banco em: {dbPath}");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
