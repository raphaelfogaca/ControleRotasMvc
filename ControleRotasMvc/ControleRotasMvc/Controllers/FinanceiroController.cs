﻿using ControleRotasMvc.DAO;
using ControleRotasMvc.Filtros;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Globalization;

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
        public ActionResult Adiciona(Financeiro docfin, int qtdProvisionar)
        {
            AlunoEntity dbAluno = new AlunoEntity();
            Aluno aluno = new Aluno();
            aluno = dbAluno.BuscaAlunoPorId(docfin.AlunoId);

            FinanceiroEntity db = new FinanceiroEntity();
            IList<FinanceiroViewModel> financeiro = db.DocumentoFinanceiro();

            docfin.EmpresaId = aluno.EmpresaId;

            while (qtdProvisionar > 0)
            {
                db.Gravar(docfin);
                docfin.Vencimento = docfin.Vencimento.AddMonths(1);
                qtdProvisionar--;
                docfin.Id = 0;
            }
            return RedirectToAction("Index", "Financeiro");
        }

        [Route("Financeiro/Alterar", Name = "Alterar")]
        public Financeiro Alterar(Financeiro docfin)
        {
            FinanceiroEntity dao = new FinanceiroEntity();
            dao.Alterar(docfin);
            return (docfin);
        }

        [Route("Financeiro/GerarBoleto", Name = "GerarBoleto")]
        public Financeiro GerarBoleto(Financeiro docfin)
        {
            FinanceiroEntity dbFin = new FinanceiroEntity();
            Financeiro dadosDocFin = new Financeiro();
            dadosDocFin = dbFin.BuscarFinanceiroPorId(docfin.Id);

            AlunoEntity dbAluno = new AlunoEntity();
            Aluno aluno = new Aluno();
            aluno = dbAluno.BuscaAlunoPorId(dadosDocFin.AlunoId);

            EmpresaEntity dbEmp = new EmpresaEntity();
            Empresa dadosEmpresa = new Empresa();
            dadosEmpresa = dbEmp.BuscaEmpresaPorId(aluno.EmpresaId);         

            AlunoEntity dbAlun = new AlunoEntity();
            Aluno dadosAluno = new Aluno();
            dadosAluno = dbAlun.BuscaAlunoPorId(dadosDocFin.AlunoId);

            EnderecoEntity dbEnd = new EnderecoEntity();
            Endereco dadosEnd = new Endereco();
            dadosEnd = dbEnd.BuscarEnderecoPorAlunoId(dadosAluno.Id);

             //string url = "https://ptsv2.com/t/yq6or-1572481983/post";
            string url = "https://ws.pagseguro.uol.com.br/recurring-payment/boletos?email=" +
            dadosEmpresa.emailPagseguro + "&token="+
            dadosEmpresa.tokenPagSeguro;            

            PostRequest(url, dadosDocFin, dadosAluno, dadosEnd);
            return (docfin);
        }

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

        async static void PostRequest(string url, Financeiro docfin, Aluno dadosAluno, Endereco dadosEnd)
        {
            //falta buscar dados do boleto para preencher as variaveis
            var obj = new BoletoTeste()
            {

                reference = "1",
                firstDueDate = docfin.Vencimento.ToString("yyyy-MM-dd"), //vencimento
                numberOfPayments = "1",
                periodicity = "monthly",
                amount = docfin.Valor.ToString("000.00",CultureInfo.InvariantCulture),
                instructions = "juros de 1% ao dia e mora de 5,00",
                description = "aula particular",
                customer = new Cliente
                {
                    document = new Document
                    {
                        type = "CPF",
                        value = dadosAluno.CpfResponsavel
                    },
                    name = dadosAluno.NomeResponsavel,
                    email = dadosAluno.EmailResponsavel,
                    phone = new Phone
                    {
                        areaCode = dadosAluno.TelefoneResponsavel.Substring(0,2),
                        number = dadosAluno.TelefoneResponsavel.Substring(2),
                    },
                    address = new Address
                    {
                        postalCode = dadosEnd.Cep,
                        street = dadosEnd.Logradouro,
                        number = dadosEnd.Numero,
                        city = dadosEnd.Cidade,
                        district = dadosEnd.Bairro,
                        state = dadosEnd.Estado
                    }
                }
            };



            //transformando em Json
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType.CharSet = "ISO-8859-1";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url, content))
                {
                    using (HttpContent resposta = response.Content)
                    {
                        string mycontent = await resposta.ReadAsStringAsync();
                        RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(mycontent);
                        Boleto boleto = rootObject.Boletos.FirstOrDefault();

                        FinanceiroEntity dao = new FinanceiroEntity();

                        docfin = dao.BuscarFinanceiroPorId(docfin.Id);
                        docfin.BoletoBarcode = boleto.Barcode;
                        docfin.BoletoCode = boleto.Code;
                        docfin.BoletoPaymentLink = boleto.PaymentLink;
                        docfin.BoletoVencimento = boleto.DueDate;
                        dao.Alterar(docfin);
                    }
                }
            }

        }

        public static Boleto GerarBoletoPagSeguro(int id)
        {
            string resultado = "{\"boletos\":[{\"code\":\"EDA6DEA7-10CB-4AF9-9C6F-FFD965BE963F\",\"paymentLink\":\"https://pagseguro.uol.com.br/checkout/payment/booklet/print.jhtml?c=c391274ab4b4208fad7df340226c2b7a56cfc3281e69429ae1854a9ee3418219fd11631b151f97d2\",\"barcode\":\"03399853012970000035849932701011980190000003100\",\"dueDate\":\"2019-09-21\"}]}";
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(resultado);
            Boleto boleto = rootObject.Boletos.FirstOrDefault();
            return boleto;
        }

        public class BoletoTeste
        {
            public string reference { get; set; }// "reference": "PEDIDO123321",
            public string firstDueDate { get; set; }//    "firstDueDate": "2019-09-09",
            public string numberOfPayments { get; set; } //    "numberOfPayments": "1",
            public string periodicity { get; set; }//    "periodicity": "monthly",
            public string amount { get; set; }//    "amount": "19.87",
            public string instructions { get; set; }//    "instructions": "juros de 1% ao dia e mora de 5,00",
            public string description { get; set; }//    "description": "Assinatura de Sorvete",  
            public Cliente customer { get; set; }// dados do comprador
        }

        public class Cliente
        {
            public Document document { get; set; }
            public string name { get; set; } // "name": "Alini QA"
            public string email { get; set; } // "email": "compradoralini@xpto.com.br",
            public Phone phone { get; set; }
            public Address address { get; set; }
        }

        public class Document
        {
            public string type { get; set; } //"type": "CPF",
            public string value { get; set; } //  "value": "02496340150"
        }

        public class Phone
        {
            public string areaCode { get; set; } //"areaCode": "11",
            public string number { get; set; } // "number": "80804040"
        }

        public class Address
        {
            public string postalCode { get; set; } // "postalCode": "01046010",
            public string street { get; set; } // "street": "Av. Ipiranga",
            public string number { get; set; } // "number": "100",
            public string district { get; set; } //  "district": "Republica",
            public string city { get; set; } // "city": "Sao Paulo",
            public string state { get; set; } // "state": "SP"
        }

        public class Boleto
        {
            public string Code { get; set; }
            public string PaymentLink { get; set; }
            public string Barcode { get; set; }
            public string DueDate { get; set; }
        }

        public class RootObject
        {
            public List<Boleto> Boletos { get; set; }
        }
    }
}
