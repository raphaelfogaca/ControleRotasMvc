using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; } // "postalCode": "01046010",
        public string Logradouro { get; set; } // "street": "Av. Ipiranga",
        public string Numero { get; set; } // "number": "100",
        public string Bairro { get; set; } //  "district": "Republica",
        public string Cidade { get; set; } // "city": "Sao Paulo",
        public string Estado { get; set; } // "state": "SP"
        public int AlunoId { get; set; }
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
    }
}