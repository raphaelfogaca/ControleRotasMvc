using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class FinanceiroEntity : DbContext
    {

        public IList<Financeiro> DocumentoFinanceiro()
        {
            var repo = new ControleRotasContext();
            return repo.Financeiros.ToList();
        }

        public bool Gravar(Financeiro docfin)
        {

            try
            {

                using (var repo = new ControleRotasContext())
                {
                    repo.Financeiros.Add(docfin);
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