using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class EnderecoEntity : DbContext
    {
        public bool Gravar(Endereco endereco)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Enderecos.Add(endereco);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Endereco BuscarEnderecoPorAlunoId (int id)
        {
            using (var contexto = new ControleRotasContext())
            {
                var q = contexto.Enderecos
                                    .Where(c => c.AlunoId == id)
                                    .FirstOrDefault();
                return q;              
            }
        }
    }
}