using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class EmpresaEntity
    {
        public bool Gravar(Empresa empresa)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Empresas.Add(empresa);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public IQueryable <Empresa> Empresas(string Pesquisa = "")
        {
            ControleRotasContext db = new ControleRotasContext();
            var q = db.Empresas.AsQueryable();
            q = q.Where(c => c.Nome.Contains(Pesquisa));
            q.ToList();
            return q;
        }

        public Empresa BuscaEmpresaPorId(int id)
        {
            using (var contexto = new ControleRotasContext())
            {
                return contexto.Empresas.Find(id);

            }
        }
    }
}