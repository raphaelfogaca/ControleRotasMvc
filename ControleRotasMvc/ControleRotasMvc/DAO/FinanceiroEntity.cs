using ControleRotasMvc.Controllers;
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
        public IList<FinanceiroViewModel> DocumentoFinanceiro()
        {
            var repo = new ControleRotasContext();
            var financeiros = (from f in repo.DocumentosFinanceiros
                               join a in repo.Alunos on f.AlunoId equals a.Id
                               select new
                               {
                                   f,
                                   a.Nome
                               }).ToList();

            return financeiros.Select(n => new FinanceiroViewModel()
            {   Nome = n.Nome,
                Id = n.f.Id,
                AlunoId = n.f.AlunoId,
                Situacao = n.f.Situacao,
                Valor = n.f.Valor,
                Vencimento = n.f.Vencimento,
            }).ToList();
        }

        public IQueryable<Financeiro> Documentos(int Pesquisa = 0)
        {            
            ControleRotasContext db = new ControleRotasContext();
            var q = db.DocumentosFinanceiros.AsQueryable();
            q = q.Where(c => c.Id >(Pesquisa));
            q.ToList();
            return q;
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


        public Financeiro BuscarFinanceiroPorId(int Pesquisa)
        {
            ControleRotasContext db = new ControleRotasContext();
            return db.DocumentosFinanceiros.Find(Pesquisa);

        }

        public IList<FinanceiroViewModel> DocumentosPorAluno(int Pesquisa)
        {
            var repo = new ControleRotasContext();
            var financeiros = (from f in repo.DocumentosFinanceiros
                               join a in repo.Alunos on f.AlunoId equals a.Id                              
                               where f.AlunoId == Pesquisa
                               select new
                               {
                                   f,
                                   a.Nome
                               }).ToList();

            return financeiros.Select(n => new FinanceiroViewModel()
            {
                Nome = n.Nome,
                Id = n.f.Id,
                AlunoId = n.f.AlunoId,
                Situacao = n.f.Situacao,
                Valor = n.f.Valor,
                Vencimento = n.f.Vencimento,      
                
            }).ToList();
        }

    }

 
}

