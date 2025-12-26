using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionClinique.Shared.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prénom est requis.")]
        public string Prenom { get; set; } = string.Empty;

        public DateTime DateNaissance { get; set; }

        public string Adresse { get; set; } = string.Empty;

        [Phone]
        public string Telephone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Navigation properties
        [JsonIgnore]
        public List<RendezVous>? RendezVous { get; set; }
    }
}
