using AppCore.DataAccess.Configs;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Contexts
{
    public class HastaneContext : DbContext
    {
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoktorHastane>()
                .HasKey(t => new { t.DoktorId, t.HastaneId });

            modelBuilder.Entity<DoktorHastane>()
                .HasOne(dh => dh.Doktor)
                .WithMany(d => d.doktorHastaneler)
                .HasForeignKey(dh => dh.DoktorId);

            modelBuilder.Entity<DoktorHastane>()
                .HasOne(dh => dh.Hastane)
                .WithMany(h => h.doktorHastaneler)
                .HasForeignKey(dh => dh.HastaneId)
                // DeleteBehavior değeri NoAction olmalıdır. Çünkü Hastaneye kayıtlı doktorlar var ise o tablo silinmemelidir. Aksi takdirde tüm verileri kaybedebiliriz.
                .OnDelete(DeleteBehavior.NoAction);

           // Doktor Tc No unique olmalıdır. Sadece bir kişiye ait tc no değeri olabilir.
            modelBuilder.Entity<Doktor>(doktor => { doktor.HasIndex(d => d.DoktorTcNo).IsUnique();
            });

        }
        
    }
}
