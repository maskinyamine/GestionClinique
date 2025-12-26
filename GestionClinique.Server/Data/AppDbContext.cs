using Microsoft.EntityFrameworkCore;
using GestionClinique.Shared.Models;

namespace GestionClinique.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Facture> Factures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configurations additionnelles si nécessaire
            modelBuilder.Entity<Chambre>().Property(c => c.PrixJournalier).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Medicament>().Property(m => m.Prix).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Facture>().Property(f => f.MontantTotal).HasColumnType("decimal(18,2)");
        }
    }
}
