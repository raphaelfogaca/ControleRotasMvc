using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Cor { get; set; }
        public bool IsFullDay { get; set; }
        public int EmpresaId { get; set; }
        public int AlunoId { get; set; }
        public int GroupId { get; set; }
        public string DaysOfWeek { get; set; }



    }
}