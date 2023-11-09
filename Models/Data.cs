using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Data")]
    public class Data
    {
        [Column("DataId")]
        [Display(Name = "Código da Data")]

        public int Id { get; set; }

        [ForeignKey("AlunoId")]
        public int AlunoId { get; set; }

        public Aluno? Aluno { get; set; }

        [ForeignKey("Livro")]

        public int LivroId { get; set; }

        public Livro? Livro { get; set; }

        [Column("DataRetirada")]
        [Display(Name = "Data de Retirada")]

        public DateTime DataRetirada { get; set; }

        [Column("DataDevolucao")]
        [Display(Name = "Data de Devolução")]

        public DateTime DataDevolucao { get; set; }

        [Column("Devolvido")]
        [Display(Name = "Devolvido")]
        public bool Devolvido { get; set; }

        [Column("NaoDevolvido")]
        [Display(Name = " Não Devolvido")]
        public bool NaoDevolvido { get; set; }
    }
}
