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

        public bool Gravar(Nota[] nota)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    int c = nota.Count() - 1;
                    int i = 0;
                    do
                    {
                        Nota nt = new Nota();
                        nt = nota[i];
                        repo.Notas.Add(nt);
                        repo.SaveChanges();
                        i++;
                    } while (i <= c);
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