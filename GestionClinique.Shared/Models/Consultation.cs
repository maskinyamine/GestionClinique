using System.ComponentModel.DataAnnotations;

namespace GestionClinique.Shared.Models
{
    public class Consultation
    {
        public int Id { get; set; }

        public DateTime DateConsultation { get; set; }

        public string Diagnostic { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        // Relation avec RendezVous
        public int RendezVousId { get; set; }
        public RendezVous? RendezVous { get; set; }
    }
}
