﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Models
{
    public class Aluno
    {
        public Aluno()
        {
            MateriaAlunos = new HashSet<MateriaAlunos>();
            Notas = new HashSet<Nota>();
            
        }

        public int Id { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public String NomeResponsavel { get; set; }
        public String EmailResponsavel { get; set; }
        public String CpfResponsavel { get; set; }
        public String TelefoneResponsavel { get; set; }
        public int AulaSegunda { get; set; }
        public int AulaTerca { get; set; }
        public int AulaQuarta { get; set; }
        public int AulaQuinta { get; set; }
        public int AulaSexta { get; set; }
        public int AulaSabado { get; set; }
        public int AulaDomingo { get; set; }
       // public String DiasAulas { get; set; }
        public int EmpresaId { get; set; }

        public virtual IEnumerable<MateriaAlunos> MateriaAlunos { get; set; }
        public virtual IEnumerable<Nota> Notas { get; set; }

    }


}