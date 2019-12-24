using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class Nota
    {

        public Nota()
        {
        }

       public int Id { get; set; }
       public float Bimestre1 { get; set; }
       public float Bimestre2 { get; set; }
       public float Bimestre3 { get; set; }
       public float Bimestre4 { get; set; }
       //public float ValorNota { get; set; }
       public int AlunoId { get; set; }
       public virtual Aluno Aluno { get; set; }
       public int MateriaId { get; set; }
       public string Materia { get; set; }
       
    }
}