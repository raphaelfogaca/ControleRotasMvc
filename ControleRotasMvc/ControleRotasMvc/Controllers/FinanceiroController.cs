using ControleRotasMvc.DAO;
using ControleRotasMvc.Filtros;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    //[AutorizacaoFilter]
    public class FinanceiroController : Controller
    {
        //GET: Mensalidade
        public ActionResult Index()
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            IList<FinanceiroViewModel> docfin = dao.DocumentoFinanceiro();

            AlunoEntity dbAluno = new AlunoEntity();
            IQueryable<Aluno> aluno = dbAluno.Alunos();
            ViewBag.Aluno = aluno;


            return View(docfin);
        }

        [Route("Financeiro/Cadastro", Name = "Cadastro")]
        public ActionResult Cadastro()
        {
            AlunoEntity dbAluno = new AlunoEntity();
            IQueryable<Aluno> aluno = dbAluno.Alunos();
            ViewBag.Aluno = aluno; 
            
            return View(aluno);
        }

        [Route("financeiro/{id}", Name = "Deletar")]
        public ActionResult Deletar(Financeiro docfin)
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            dao.Deletar(docfin);
            return RedirectToAction("Index");
        }

        [Route("financeiro/liquidar/{id}", Name = "Liquidar")]
        public ActionResult Liquidar(Financeiro docfin)
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            Financeiro documento = dao.BuscarFinanceiroPorId(docfin.Id);
            documento.Situacao = 1;
            dao.Alterar(documento);
            return RedirectToAction("Index");
        }

        [Route("Financeiro/Adiciona", Name = "Adiciona")]
        public ActionResult Adiciona(Financeiro docfin, int qtdProvisionar, Aluno aluno)
        {

            FinanceiroEntity db = new FinanceiroEntity();
            IList<FinanceiroViewModel> financeiro = db.DocumentoFinanceiro();

            //armazenar objeto Empresa na sessão//
            var empresaLogada = Session["empresaLogada"];
            Empresa empresa = (Empresa)Session["empresaLogada"];
            docfin.EmpresaId = empresa.Id;

            while (qtdProvisionar > 0)
            {
                db.Gravar(docfin);
                docfin.Vencimento = docfin.Vencimento.AddMonths(1);
                qtdProvisionar--;
                docfin.Id = 0;
            }
            return RedirectToAction("Index", "Financeiro");
        }

        //public Financeiro Alterar(Financeiro docfin)
        //{
        //    FinanceiroEntity dao = new FinanceiroEntity();
        //    dao.Alterar(docfin);
        //    return (docfin);
        //}

        [Route("Financeiro/Buscar", Name = "Buscar")]
        public ActionResult BuscarFinanceiro(int Pesquisa)
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            var listaFinanceiro = dao.DocumentosPorAluno(Pesquisa);

            AlunoEntity dbAluno = new AlunoEntity();
            IQueryable<Aluno> aluno = dbAluno.Alunos();
            ViewBag.Aluno = aluno;

            return View("Index", listaFinanceiro);
        }
    }
}
