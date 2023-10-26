using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Genero")]
    public class Genero
    {
        [Column("GeneroId")]
        [Display(Name = "Código do Gênero")]

        public int Id { get; set; }

        [Column("GeneroNome")]
        [Display(Name = "Nome do Gênero")]

        public string Nome { get; set; } = string.Empty;
    }
}
