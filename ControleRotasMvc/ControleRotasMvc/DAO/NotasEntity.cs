using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class NotasEntity : DbContext
    {
        public IList<Nota> Notas()
        {
            var repo = new ControleRotasContext();
            return repo.Notas.ToList();
        }

        public bool Gravar(Nota nota)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Notas.Add(nota);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch (Exception EX)
            {

                return false;
            }
        }
    }
}