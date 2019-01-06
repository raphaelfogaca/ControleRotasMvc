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
            var financeiros = (from f in repo.DocumentosFinanceiros
                              join a in repo.Alunos on f.AlunoId equals a.Id
                              select new
                              {
                                  f,
                                  a.Nome
                              }).ToList();

            return financeiros.Select(n => new Financeiro()
            {   Id = n.f.Id,
                AlunoId = n.f.AlunoId,
                AlunoNome = n.Nome,
                Situacao = n.f.Situacao,
                Valor = n.f.Valor,
                Vencimento = n.f.Vencimento,
            }).ToList();
        }

        public bool Gravar(Financeiro docfin)
        {

            try
            {

                using (var repo = new ControleRotasContext())
                {
                    repo.DocumentosFinanceiros.Add(docfin);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch (Exception EX)
            {

                return false;
            }
        }

        public bool Deletar(Financeiro docfin)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.DocumentosFinanceiros.Remove(docfin);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch (Exception EX)
            {
                return false;
            }
        }

        public bool Alterar(Financeiro docfin)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {

                    repo.DocumentosFinanceiros.Update(docfin);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch (Exception EX)
            {
                return false;
            }
        }
        public Financeiro BuscarFinanceiroPorId(int id)
        {
            using (var repo = new ControleRotasContext())
            {
                return repo.DocumentosFinanceiros.Find(id);
            }
        }

    }

 
}

