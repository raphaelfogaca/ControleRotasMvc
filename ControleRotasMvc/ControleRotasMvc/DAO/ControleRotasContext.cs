using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleRotasMvc;
using ControleRotasMvc.Models;

namespace ControleRotasMvc.DAO

{
    public class ControleRotasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaAlunos> MateriaAlunos { get; set; }
        public DbSet<Financeiro> DocumentosFinanceiros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = ControleRotasDB; Trusted_Connection=Yes");          
        }
    }
}
