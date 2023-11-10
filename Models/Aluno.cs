using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Column("AlunoId")]
        [Display(Name = "Código do Aluno")]

        public int Id { get; set; }

        [Column("AlunoNome")]
        [Display(Name = "Nome do Aluno")]

        public string Nome { get; set; } = string.Empty;

        [Column("AlunoRm")]
        [Display(Name = "RM do Aluno")]

        public int Rm { get; set; }

    }
}
