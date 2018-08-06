using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Models
{
    public class Usuario
    {
        public int UsuarioTipo { get; set; }               

        public String UsuarioLogin { get; set; }

        public String UsuarioNome { get; set; }

        public String UsuarioSobrenome { get; set; }

        public String UsuarioEmail { get; set; }

        public String UsuarioSenha { get; set; }

        public int Status { get; set; }

        public int Id { get; set; } 
    }
}