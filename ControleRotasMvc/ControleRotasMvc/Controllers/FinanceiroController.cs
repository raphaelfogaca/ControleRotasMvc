using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            
            while (qtdMaterias > 0)
            {
                db3.Gravar(docfin);
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
        
        public Financeiro Alterar(Financeiro docfin)
        {
             FinanceiroEntity dao = new FinanceiroEntity();
             dao.Alterar(docfin);
             return(docfin);
        }
    }
}
