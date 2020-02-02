using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class DiasAulaEntity : DbContext
    {
        public IQueryable<DiasAula> DiasAula(string Pesquisa = "")
        {
            ControleRotasContext db = new ControleRotasContext();
            var q = db.DiasAula.AsQueryable();
            q = q.Where(c => c.Descricao.Contains(Pesquisa));
            q.ToList();
            return q;
        }
    }
}