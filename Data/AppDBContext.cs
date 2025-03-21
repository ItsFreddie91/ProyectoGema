using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gasto>(tb => {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Descripcion).HasMaxLength(100);;
                tb.Property(col => col.Monto).HasColumnType("decimal(18,2)");
                tb.Property(col => col.Fecha).HasMaxLength(20);
            
            });

            modelBuilder.Entity<Ingreso>(tb => {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Descripcion).HasMaxLength(100);;
                tb.Property(col => col.Monto).HasColumnType("decimal(18,2)");
                tb.Property(col => col.Fecha).HasMaxLength(20);
            
            });

            modelBuilder.Entity<Gasto>().ToTable("Gastos");
            modelBuilder.Entity<Ingreso>().ToTable("Ingresos");
            
        }
    }
}
