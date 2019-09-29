using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class FinanceiroViewModel
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int Situacao { get; set; }
        public float Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public Endereco Endereco { get; set; }

        public string BoletoPaymentLink { get; set; }

    }
}