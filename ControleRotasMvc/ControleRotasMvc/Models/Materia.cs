using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class Materia
    {

        public Materia()
        {
            MateriaAlunos = new HashSet<MateriaAlunos>();

        }

        public int Id { get; set; }
        public String Nome { get; set; }
       // public IList<MateriaAluno> Materias { get; set; }
        public virtual IEnumerable<MateriaAlunos> MateriaAlunos { get; set; }
       
    }
}