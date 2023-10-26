using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Livro")]
    public class Livro
    {
        [Column("LivroId")]
        [Display(Name = "Código do Livro")]

        public int Id { get; set; }

        [Column("LivroNome")]
        [Display(Name = "Título do Livro")]

        public string Nome { get; set; } = string.Empty;

        [Column("LivroNumero")]
        [Display(Name = "Código do Livro")]

        public int Numero { get; set; }

        [ForeignKey("GeneroId")]

        public int GeneroId { get; set; }

        public Genero? Genero { get; set; }

       
    }
}
