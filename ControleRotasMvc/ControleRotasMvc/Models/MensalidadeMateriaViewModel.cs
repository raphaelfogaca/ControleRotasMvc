using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class MensalidadeMateriaViewModel
    {
        public IList<Mensalidade> Mensalidades { get; set; }
        public IList<Materia> Materias { get; set; }
    }
}