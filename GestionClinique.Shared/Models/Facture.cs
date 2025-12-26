using System.ComponentModel.DataAnnotations;

namespace GestionClinique.Shared.Models
{
    public class Facture
    {
        public int Id { get; set; }

        public DateTime DateFacture { get; set; }

        public decimal MontantTotal { get; set; }

        public bool EstPaye { get; set; } = false;

        // Relation avec Consultation
        public int ConsultationId { get; set; }
        public Consultation? Consultation { get; set; }
    }
}
