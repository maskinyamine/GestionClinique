using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionClinique.Shared.Models
{
    public class Medecin
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = string.Empty;

        [Required]
        public string Prenom { get; set; } = string.Empty;

        public string Specialite { get; set; } = string.Empty;

        [Phone]
        public string Telephone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Navigation
        [JsonIgnore]
        public List<RendezVous>? RendezVous { get; set; }
    }
}
