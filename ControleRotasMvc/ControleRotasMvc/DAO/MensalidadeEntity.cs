using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class MensalidadeEntity : DbContext
    {

        public IList<Mensalidade> Mensalidades()
        {
            var repo = new ControleRotasContext();
            return repo.Mensalidades.ToList();
        }

        public bool Gravar(Mensalidade mensalidade)
        {

            try
            {

                using (var repo = new ControleRotasContext())
                {
                    repo.Mensalidades.Add(mensalidade);
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