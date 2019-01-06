using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            MateriaEntity dao = new MateriaEntity();
            IQueryable<Materia> materia = dao.Materias();
            return View(materia);
        }

        public ActionResult Cadastro()
        {
            MateriaEntity dao = new MateriaEntity();
            IQueryable<Materia> materia = dao.Materias();
            return View(materia);

        }

        public ActionResult BuscarMateria (string Pesquisa)
        {
            MateriaEntity dao = new MateriaEntity();
            var listaMaterias = dao.BuscaMateriaPorNome(Pesquisa);
            return View("Index", listaMaterias);
        }

        public ActionResult Adiciona(Materia materia)
        {
            MateriaEntity db2 = new MateriaEntity();
            if (db2.BuscaMateria(materia.Nome))
            {
                ModelState.AddModelError("materia.MateriaExistente", "Esta matéria já está cadastrada");
            }
            if (ModelState.IsValid)
            {
                MateriaEntity db = new MateriaEntity();
                db.Gravar(materia);
                return RedirectToAction("Index", "Materia");

            }
            else
            {
                ViewBag.Usuario = materia;
                MateriaEntity db = new MateriaEntity();
                return View("Cadastro");
            }
        }

        public ActionResult Deletar (Materia materia)
        {
            MateriaEntity dao = new MateriaEntity();
            dao.Deletar(materia);
            return RedirectToAction("Index");
        }
    }
}