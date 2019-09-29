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
        public ActionResult Adiciona(Aluno aluno, int[] materias, Nota[] nota, Endereco endereco, string[] diasAula)
        {

            ///cadastro automatico aluno///
            //aluno.Nome = "raphael";
            //aluno.NomeResponsavel = "Jose";
            //aluno.Email = "raphael.fogaca@hotmail2.c23om";
            //aluno.AulaSexta = 1;
            //aluno.Telefone = "123456";
            //aluno.EmailResponsavel = "liliane@gmail.com";

            foreach (var item in diasAula)
            {
                aluno.DiasAula = aluno.DiasAula + "," + item;
            }

            //armazenar objeto Empresa na sessão//
            var empresaLogada = Session["empresaLogada"];
            Empresa empresa = (Empresa)Session["empresaLogada"];
            aluno.EmpresaId = empresa.Id;

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
                return RedirectToAction("Index", "Aluno");
            }
            else
            {
                return View("Cadastro");
                //testando sem json
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                //ViewBag.Aluno = aluno;
                //AlunoEntity db = new AlunoEntity();                
                //return Json(true, JsonRequestBehavior.AllowGet);
                //testando sem json
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
            ViewBag.Notas = db.Notas.ToList();

            List<int> MateriasDoAluno = new List<int>();
            if (aluno != null && aluno.MateriaAlunos != null)
            {
                MateriasDoAluno = aluno.MateriaAlunos.Select(n => n.MateriaId).ToList(); //[2]
            }

            //List<int> NotasDoAluno = new List<int>();
            //if (aluno != null && aluno.Notas != null)
            //{
            //    NotasDoAluno = aluno.Notas.Select(n => n.AlunoId).ToList();
            //}

            //ViewBag.NotasDoAluno = Nota;
            ViewBag.MateriasDoAluno = MateriasDoAluno;


            return View(aluno);
        }

        public ActionResult BuscarAluno(string Pesquisa)
        {
            AlunoEntity dao = new AlunoEntity();
            var listaAluno = dao.BuscarAlunoPorNome(Pesquisa);
            return View("Index", listaAluno);
        }


    }
}