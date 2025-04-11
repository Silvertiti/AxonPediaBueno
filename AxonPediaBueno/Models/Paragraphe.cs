using System.ComponentModel.DataAnnotations;

namespace AxonPediaBueno.Models
{
    public class Paragraphe
    {
        public int Id { get; set; }
        public string? NomArticle { get; set; }
        public string? TypeArticle { get; set; }
        public string? Contenu { get; set; }
    }
}
