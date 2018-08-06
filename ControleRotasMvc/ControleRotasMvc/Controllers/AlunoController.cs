﻿using ControleRotasMvc.DAO;
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
        public ActionResult Adiciona(Aluno aluno, int[] materias, Financeiro mensalidade, int qtdMaterias)
        {
            AlunoEntity db2 = new AlunoEntity();
            //aluno.MateriaAluno = materias.Select(o => new MateriaAluno() { MateriaId = o }).ToList();
            aluno.MateriaAlunos = materias.Select(n => new MateriaAlunos() { MateriaId = n }).ToList();

            

            if (db2.BuscaAlunoPorEmail(aluno.Email))
            {
                ModelState.AddModelError("aluno.EmailExistente", "Este email já está cadastrado");
            }
            if (ModelState.IsValid)
            {
                
                AlunoEntity db = new AlunoEntity();                             
                db.Gravar(aluno);
                mensalidade.AlunoId = aluno.Id;
               // mensalidade.Vencimento = DateTime.Now;
                // gravar mensalidades
                
                FinanceiroController mens = new FinanceiroController();                
                mens.Cadastrar(mensalidade,qtdMaterias);
                

                return RedirectToAction("Index", "Aluno");

            }
            else
            {
                ViewBag.Aluno = aluno;
                AlunoEntity db = new AlunoEntity();
                return View("Cadastro");
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