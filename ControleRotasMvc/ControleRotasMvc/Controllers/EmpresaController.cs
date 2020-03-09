using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            EmpresaEntity dao = new EmpresaEntity();
            IQueryable<Empresa> empresa = dao.Empresas();
            return View(empresa);
        }

        public ActionResult Cadastro()
        {
            EmpresaEntity dao = new EmpresaEntity();
            IQueryable<Empresa> empresa = dao.Empresas();
            return View(empresa);
        }

        public ActionResult Adiciona(Empresa empresa, Endereco endereco)
        {           
            if (ModelState.IsValid)
            {
                EmpresaEntity db = new EmpresaEntity();
                EnderecoEntity db2 = new EnderecoEntity();
                db.Gravar(empresa);
                endereco.EmpresaId = empresa.Id;
                db2.Gravar(endereco);
                return RedirectToAction("Index", "Empresa");

            }
            else
            {               
                return View("Cadastro", "Empresa");
            }
        }
        [Route("empresas/{id}", Name = "VisualizaEmpresa")]
        public ActionResult Visualiza(int id)
        {
            EmpresaEntity db = new EmpresaEntity();
            Empresa empresa = db.BuscaEmpresaPorId(id);
            ViewBag.Empresa = empresa;
            return View(empresa);
        }
    }
}