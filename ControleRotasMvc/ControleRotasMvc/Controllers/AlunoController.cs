using ControleRotasMvc.DAO;
using ControleRotasMvc.Filtros;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    //[AutorizacaoFilter]
    public class AlunoController : Controller
    {
        // GET: Aluno
        [Route("alunos", Name = "ListaAlunos")]
        public ActionResult Index()
        {
            AlunoEntity dao = new AlunoEntity();
            IQueryable<Aluno> aluno = dao.Alunos();
            return View(aluno);
        }

        public ActionResult Cadastro()
        {
            MateriaEntity dao2 = new MateriaEntity();
            string pesquisa = "";
            IQueryable<Materia> materia = dao2.Materias(pesquisa);
            DiasAulaEntity diasAula = new DiasAulaEntity();
            ViewBag.DiasAula = diasAula.DiasAula();

            return View(materia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Aluno aluno, int[] materias, Nota[] nota, Endereco endereco, string[] diasAula, DateTime horarioStart, DateTime horarioEnd)
        {

            if (diasAula != null)
            {
                aluno.DiasAula = string.Join(",", diasAula);
            }
            
            
            //armazenar objeto Empresa na sessão//
            //var empresaLogada = Session["empresaLogada"];
            //Empresa empresa = (Empresa)Session["empresaLogada"];
            //aluno.EmpresaId = empresa.Id;
            //aluno.EmpresaId = 1;

            AlunoEntity db2 = new AlunoEntity();

            aluno.MateriaAlunos = materias.Select(n => new MateriaAlunos() { MateriaId = n }).ToList();


            if (db2.BuscaAlunoPorEmail(aluno.Email))
            {
                ModelState.AddModelError("aluno.EmailExistente", "Este email já está cadastrado");
            }
            if (ModelState.IsValid)
            {

                AlunoEntity db = new AlunoEntity();
                db.Gravar(aluno);

                MateriaAlunoEntity materiaAlunos = new MateriaAlunoEntity();
                materiaAlunos.Gravar(aluno.MateriaAlunos, aluno);

                endereco.AlunoId = aluno.Id;
                EnderecoEntity dbEndereco = new EnderecoEntity();
                dbEndereco.Gravar(endereco);

                int c = nota.Count() - 1;
                int abc = aluno.Id;

                NotaController not = new NotaController();

                while (c >= 0)
                {
                    nota[c].AlunoId = aluno.Id;
                    c--;
                }
                not.Cadastrar(nota);

                EventoController evento = new EventoController();
                evento.CadastrarEvento(horarioStart, horarioEnd, aluno);
                return RedirectToAction("Index", "Aluno");
            }
            else
            {
               
                //testando sem json
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                //ViewBag.Aluno = aluno;
                //AlunoEntity db = new AlunoEntity();                
                //return Json(true, JsonRequestBehavior.AllowGet);
                //testando sem json
                return View("Cadastro");
            }
        }

        [Route("alunos/{id}", Name = "VisualizaAluno")]
        public ActionResult Visualiza(int id)
        {
            //AlunoEntity db = new AlunoEntity();
            ControleRotasContext db = new ControleRotasContext();
            Aluno aluno = db.Alunos.Where(n => n.Id == id).FirstOrDefault();
            aluno.MateriaAlunos = db.MateriaAlunos.Where(n => n.AlunoId == aluno.Id).ToList();//porque tenho que ter este? e tbm o [2]

            aluno.Notas = db.Notas.Where(n => n.AlunoId == aluno.Id).ToList();
            ViewBag.Aluno = aluno;
            ViewBag.Materias = db.Materias.ToList();
            NotasEntity dbNota = new NotasEntity();
            ViewBag.Notas = dbNota.BuscarNotaPorAlunoId(aluno.Id);

            List<int> MateriasDoAluno = new List<int>();
            if (aluno != null && aluno.MateriaAlunos != null)
            {
                MateriasDoAluno = aluno.MateriaAlunos.Select(n => n.MateriaId).ToList(); //[2]
            }

            DiasAulaEntity diasAula = new DiasAulaEntity();
            ViewBag.DiasAula = diasAula.DiasAula();

            EnderecoEntity enderecoDb = new EnderecoEntity();
            ViewBag.Endereco = enderecoDb.BuscarEnderecoPorAlunoId(aluno.Id);

            FinanceiroEntity financeiroDb = new FinanceiroEntity();
            ViewBag.Financeiro = financeiroDb.DocumentosPorAluno(aluno.Id);

            //List<string> listaDiasAula = aluno.DiasAula.Split(',').ToList();
            ViewBag.DiasAulaAluno = aluno.DiasAula;

            ViewBag.MateriasDoAluno = MateriasDoAluno;


            //List<int> NotasDoAluno = new List<int>();
            //if (aluno != null && aluno.Notas != null)
            //{
            //    NotasDoAluno = aluno.Notas.Select(n => n.AlunoId).ToList();
            //}
            //ViewBag.NotasDoAluno = Nota;


            return View(aluno);
        }

        [Route("aluno/Alterar", Name = "AlterarAluno")]
        public ActionResult Alterar(Aluno aluno, int[] materias, Nota[] nota, string[] diasAula, Endereco endereco)
        {
            aluno.MateriaAlunos = materias.Select(n => new MateriaAlunos() { MateriaId = n }).ToList();
            MateriaAlunoEntity materiaAlunos = new MateriaAlunoEntity();
            materiaAlunos.Gravar(aluno.MateriaAlunos, aluno);

            if (diasAula != null)
            {
                foreach (var item in diasAula)
                {
                    aluno.DiasAula = item + "," + aluno.DiasAula;
                }
            }

            int c = nota.Count() - 1;
          
            NotaController not = new NotaController();

            while (c >= 0)
            {
                nota[c].AlunoId = aluno.Id;
                c--;
            }
            not.Alterar(nota);

            EnderecoEntity dbEndereco = new EnderecoEntity();
            endereco.AlunoId = aluno.Id;
            endereco.Id = dbEndereco.BuscarEnderecoId(aluno.Id);
            dbEndereco.Alterar(endereco);

            AlunoEntity dao = new AlunoEntity();
            if (dao.Alterar(aluno) == "OK")
            {
                TempData["UserMessage"] = "Aluno alterado com sucesso!";
                return RedirectToAction("index");
            }
            else
            {
                TempData["UserMessage"] = "Erro ao alterar aluno " +aluno.Id + ".";
                return RedirectToAction("","alunos/"+aluno.Id);
            }
            
        }

        [Route("aluno/Inativar/{id}", Name = "InativarAluno")]
        public ActionResult Inativar (Aluno aluno)
        {
            AlunoEntity db = new AlunoEntity();
            aluno = db.BuscaAlunoPorId(aluno.Id);
            aluno.Situacao = 0;
            db.Alterar(aluno);
            TempData["UserMessage"] = "Aluno inativado com sucesso!";
            return RedirectToAction("index");
        }

        [Route("aluno/Ativar/{id}", Name = "AtivarAluno")]
        public ActionResult Ativar(Aluno aluno)
        {
            AlunoEntity db = new AlunoEntity();
            aluno = db.BuscaAlunoPorId(aluno.Id);
            aluno.Situacao = 1;
            db.Alterar(aluno);
            TempData["UserMessage"] = "Aluno ativado com sucesso!";
            return RedirectToAction("index");
        }

        public ActionResult BuscarAluno(string Pesquisa)
        {
            AlunoEntity dao = new AlunoEntity();
            var listaAluno = dao.BuscarAlunoPorNome(Pesquisa);
            return View("Index", listaAluno);
        }

        public ActionResult BuscarAluno2(List<string> values)
        {
            MateriaEntity dao2 = new MateriaEntity();
            string materiaId = values.FirstOrDefault();
            IQueryable<Materia> materia = dao2.BuscaMateriaPorId(Convert.ToInt16(materiaId));
            DiasAulaEntity diasAula = new DiasAulaEntity();
            ViewBag.DiasAula = diasAula.DiasAula();

            return View("Cadastro",materia);

        }



    }
}