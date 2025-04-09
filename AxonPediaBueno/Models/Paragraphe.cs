using System.ComponentModel.DataAnnotations;

namespace AxonPediaBueno.Models
{
    public class Paragraphe
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le contenu est requis.")]
        public string Contenu { get; set; }
    }
}
