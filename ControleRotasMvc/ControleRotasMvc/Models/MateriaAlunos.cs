using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class MateriaAlunos
    {

        public int Id { get; set; }
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }

    }
}