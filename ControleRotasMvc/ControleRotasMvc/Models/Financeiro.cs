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
        public int Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public int AlunoId { get; set; }
        public int Situacao { get; set; }
        public int EmpresaId { get; set; }   
        public int FormaRecebimento { get; set; }//1 dinheiro, 2 boleto     
        public string BoletoCode { get; set; }
        public string BoletoPaymentLink { get; set; }
        public string BoletoBarcode { get; set; }
        public string BoletoVencimento { get; set; }


       //public virtual IEnumerable<Aluno> Alunos { get; set; }

    }
}