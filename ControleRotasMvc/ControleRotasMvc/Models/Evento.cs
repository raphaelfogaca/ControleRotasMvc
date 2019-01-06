using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }

    }
}