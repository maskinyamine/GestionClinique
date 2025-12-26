using System.ComponentModel.DataAnnotations;

namespace GestionClinique.Shared.Models
{
    public class RendezVous
    {
        public int Id { get; set; }

        public DateTime DateHeure { get; set; }

        public string Motif { get; set; } = string.Empty;

        public string Statut { get; set; } = "Planifié"; // Planifié, Confirmé, Annulé, Terminé

        // Foreign Keys
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int MedecinId { get; set; }
        public Medecin? Medecin { get; set; }
    }
}
