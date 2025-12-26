using System.ComponentModel.DataAnnotations;

namespace GestionClinique.Shared.Models
{
    public class Chambre
    {
        public int Id { get; set; }

        [Required]
        public string Numero { get; set; } = string.Empty;

        public string Type { get; set; } = "Simple"; // Simple, Double, VIP

        public decimal PrixJournalier { get; set; }

        public bool EstOccupe { get; set; } = false;
    }
}
