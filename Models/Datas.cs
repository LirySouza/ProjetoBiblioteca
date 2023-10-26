using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Data")]
    public class Datas
    {
        [ForeignKey("AlunoId")]

        public int Id { get; set; }

        public Aluno? Aluno { get; set; }

        [ForeignKey("LivroId")]

        public int LivroId { get;set; }

        public Livro? Livro { get; set; }

        [Column("DataRetirada")]
        [Display(Name = "Data de retirada do Livro")]

        public DateTime DataRetirada { get; set; }

        [Column("DataDevolucao")]
        [Display(Name = "Data de devolução do Livro")]

        public DateTime DataDevolucao { get; set; }
    }
}
