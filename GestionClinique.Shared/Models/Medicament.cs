using System.ComponentModel.DataAnnotations;

namespace GestionClinique.Shared.Models
{
    public class Medicament
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Prix { get; set; }
    }
}
