using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleRotasMvc.Models;
using ControleRotasMvc.DAO;
using ControleRotasMvc.Filtros;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ControleRotasMvc.Controllers
{
    //[AutorizacaoFilter]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Route("usuarios", Name="ListaUsuarios")]
        
        public ActionResult Index()
        {
            UsuarioEntity dao = new UsuarioEntity();
            IList<Usuario> usuario = dao.Usuarios();
            return View(usuario);
        }

        public ActionResult Form()
        {
            ViewBag.Usuario = new Usuario();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Usuario usuario)
        {
            UsuarioEntity db2 = new UsuarioEntity();
            if (db2.BuscaUsuarioPorLogin(usuario.UsuarioLogin))
            {
                ModelState.AddModelError("usuario.LoginExistente", "Este login já está cadastrado");
            }
            if (ModelState.IsValid) {
                UsuarioEntity db = new UsuarioEntity();
                db.Gravar(usuario);
                return RedirectToAction("Index", "Usuario");

            }else
            {
                ViewBag.Usuario = usuario;
                UsuarioEntity db = new UsuarioEntity();
                return View("Form");
            }
        }

        public ActionResult Adiciona()
        {
            return View();
        }


        [Route("produtos/{id}", Name="VisualizaProduto")]
        public ActionResult Visualiza (int id)
        {
            UsuarioEntity db = new UsuarioEntity();      
            Usuario usuario = db.BuscaUsuarioPorId(id);
            ViewBag.Usuario = usuario;
            return View(usuario);
        }

        public ActionResult Decrementar(int id)
        {
            UsuarioEntity db = new UsuarioEntity();
            Usuario usuario = db.BuscaUsuarioPorId(id);
            usuario.UsuarioTipo--;
            db.Atualiza(usuario);
            return Json(usuario);
        }

        [HttpPost]
        public ActionResult CriarManual()
        {
           
            return View();
        }
    }
}