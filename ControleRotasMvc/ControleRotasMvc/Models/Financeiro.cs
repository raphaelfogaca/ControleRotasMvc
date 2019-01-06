using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ControleRotasMvc.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public int AlunoId { get; set; }
        public int Situacao { get; set; }
        [NotMapped]
        public string AlunoNome { get; set; }
                
    }
}