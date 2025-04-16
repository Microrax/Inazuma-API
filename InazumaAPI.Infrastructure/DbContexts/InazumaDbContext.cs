using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using InazumaAPI.Domain.Aggregates.Players;
using Microsoft.EntityFrameworkCore;


namespace InazumaAPI.Infrastructure.DbContexts
{
    public class InazumaDbContext : DbContext
    {
        public DbSet<PlayerModel> Players { get; set; }

        public InazumaDbContext(DbContextOptions<InazumaDbContext> options) : base(options)
        {
        }

        // Configurar la base de datos y las tablas (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerModel>(entity =>
            {
                entity.ToTable("Players");

                entity.HasKey(p => p.NombreId);

                entity.Property(p => p.NombreId).IsRequired();
                entity.Property(p => p.PE).IsRequired();
                entity.Property(p => p.PT).IsRequired();
                entity.Property(p => p.Patada).IsRequired();
                entity.Property(p => p.Control).IsRequired();
                entity.Property(p => p.Tecnica).IsRequired();
                entity.Property(p => p.Inteligencia).IsRequired();
                entity.Property(p => p.Presion).IsRequired();
                entity.Property(p => p.Fisico).IsRequired();
                entity.Property(p => p.Agilidad).IsRequired();
                entity.Property(p => p.Imagen).IsRequired();
            });
        }
    }
}
