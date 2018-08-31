using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        [Route("alunos", Name = "ListaAlunos")]
        public ActionResult Index()
        {
            AlunoEntity dao = new AlunoEntity();
            IList<Aluno> aluno = dao.Alunos();

            return View(aluno);
        }

        public ActionResult Cadastro()
        {
            //var viewmod = new MateriaAlunos(); comentada 21/07
            //ViewBag.Aluno = new Aluno();

            MateriaEntity dao2 = new MateriaEntity();
            IList<Materia> materia = dao2.Materias();

            return View(materia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Adiciona(Aluno aluno, int[] materias, Financeiro mensalidade, int qtdMaterias, Nota[] nota)
        {
            ///cadastro automatico aluno///
            aluno.Nome = "raphael";
            aluno.NomeResponsavel = "Jose";
            aluno.Email = "raphael.fogaca@hotmail.com2";
            aluno.AulaSexta = 1;
            aluno.Telefone = "123456";
            aluno.EmailResponsavel = "liliane@gmail.com";

            AlunoEntity db2 = new AlunoEntity();
            //aluno.MateriaAlunos = materias.Select(n => new MateriaAlunos() { MateriaId = n }).ToList();


            if (db2.BuscaAlunoPorEmail(aluno.Email))
            {
                ModelState.AddModelError("aluno.EmailExistente", "Este email já está cadastrado");
            }
            if (ModelState.IsValid)
            {

                AlunoEntity db = new AlunoEntity();
                db.Gravar(aluno);
                mensalidade.AlunoId = aluno.Id;

                FinanceiroController mens = new FinanceiroController();
                mens.Cadastrar(mensalidade,qtdMaterias);

                // gambiarra para buscar AlunoId e MateriaId
                /*nota.AlunoId = aluno.Id;
                MateriaAlunoEntity db3 = new MateriaAlunoEntity();
                db3.BuscaMateriaPorAlunoId(aluno.Id);
                MateriaAlunos materiaAlunos = new MateriaAlunos();
                materiaAlunos = db3.BuscaMateriaPorAlunoId(aluno.Id);
                nota.MateriaId = materiaAlunos.MateriaId;*/
                ///////////////////////////////////////////////

                NotaController not = new NotaController();
                not.Cadastrar(nota);


                //return RedirectToAction("Index", "Aluno");
                return Json(aluno, JsonRequestBehavior.AllowGet);

            }
            else
            {
                ViewBag.Aluno = aluno;
                AlunoEntity db = new AlunoEntity();
                //return View("Cadastro");
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("alunos/{id}", Name = "VisualizaAluno")]
        public ActionResult Visualiza(int id)
        {
            AlunoEntity db = new AlunoEntity();
            Aluno aluno = db.BuscaAlunoPorId(id);
            ViewBag.Aluno = aluno;
            return View(aluno);
        }


    }
}