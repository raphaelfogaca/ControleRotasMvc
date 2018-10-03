using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    public class FinanceiroController : Controller
    {
        // GET: Mensalidade
        public ActionResult Index()
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            IList<Financeiro> docfin = dao.DocumentoFinanceiro();
            return View(docfin);
        }

        public Financeiro Cadastrar(Financeiro docfin, int qtdMaterias)
        {
            FinanceiroEntity db3 = new FinanceiroEntity();            
            docfin.Situacao = 0;

            while (qtdMaterias > 0)
            { 
                db3.Gravar(docfin);
                docfin.Vencimento = docfin.Vencimento.AddMonths(1);
                qtdMaterias--;
                docfin.Id = 0;
            }
            return (docfin);
        }

        [Route("financeiro/{id}", Name = "Deletar")]
        public ActionResult Deletar(Financeiro docfin)
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            dao.Deletar(docfin);
            return RedirectToAction("Index");
        }

        //[Route("financeiro/liquidar/{id}", Name = "Liquidar")]

        public ActionResult Liquidar(Financeiro docfin)
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            Financeiro documento = dao.BuscarFinanceiroPorId(docfin.Id);
            documento.Situacao = 1;
            dao.Alterar(documento);
            return RedirectToAction("Index");
        }
        
        public Financeiro Alterar(Financeiro docfin)
        {
             FinanceiroEntity dao = new FinanceiroEntity();
             dao.Alterar(docfin);
             return(docfin);
        }
    }
}
