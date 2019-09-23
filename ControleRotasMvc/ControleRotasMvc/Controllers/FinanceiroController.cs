using ControleRotasMvc.DAO;
using ControleRotasMvc.Filtros;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;

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

            Boleto boleto = new Boleto();
            boleto = GerarBoleto(docfin.Id);
            documento.BoletoBarcode = boleto.barcode;
            documento.BoletoBarcode = boleto.barcode;
            documento.BoletoCode = boleto.code;
            documento.BoletoPaymentLink = boleto.paymentLink;
            documento.BoletoVencimento = boleto.dueDate;

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

        public static Boleto GerarBoleto(int id)
        {
            string resultado = "{\"boletos\":[{\"code\":\"EDA6DEA7-10CB-4AF9-9C6F-FFD965BE963F\",\"paymentLink\":\"https://pagseguro.uol.com.br/checkout/payment/booklet/print.jhtml?c=c391274ab4b4208fad7df340226c2b7a56cfc3281e69429ae1854a9ee3418219fd11631b151f97d2\",\"barcode\":\"03399853012970000035849932701011980190000003100\",\"dueDate\":\"2019-09-21\"}]}";
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(resultado);
            Boleto boleto = rootObject.boletos.FirstOrDefault();
            return boleto;                       
        }
        

        public class Boleto
        {
            public string code { get; set; }
            public string paymentLink { get; set; }
            public string barcode { get; set; }
            public string dueDate { get; set; }
        }

        public class RootObject
        {
            public List<Boleto> boletos { get; set; }
        }
    }
}
