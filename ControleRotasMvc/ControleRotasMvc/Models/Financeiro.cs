using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public int Vencimento { get; set; }
        public int AlunoId { get; set; }
                
    }
}