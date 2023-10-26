using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ProjetoBiblioteca.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }
        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Genero> Genero { get; set; }

        public DbSet<Livro> Livro  { get; set; }


        public DbSet<Datas> Datas { get; set; }

    }

}
