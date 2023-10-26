using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBiblioteca.Models
{
    [Table("Datas")]
    public class Datas
    {
        [Column( "DataId" ) ]
        [Display( Name = "Código da Data" ) ]

        public int Id { get; set; }

        [ForeignKey("Aluno")]
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


    }
}
