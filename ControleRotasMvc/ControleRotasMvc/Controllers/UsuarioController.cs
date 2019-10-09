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
using ControleRotasMvc.Helpers;

namespace ControleRotasMvc.Controllers
{
    [AutorizacaoFilter]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Route("usuarios", Name = "ListaUsuarios")]
        public ActionResult Index()
        {
            UsuarioEntity dao = new UsuarioEntity();
            IQueryable<Usuario> usuario = dao.Usuarios();
            ViewBag.Usuario = new Usuario();

            EmpresaEntity dbEmpresa = new EmpresaEntity();
            IQueryable<Empresa> empresa = dbEmpresa.Empresas();
            ViewBag.Empresa = empresa;

            return View(usuario);
        }

        public ActionResult Form()
        {
            ViewBag.Usuario = new Usuario();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario usuario)
        {
            usuario.UsuarioLogin = usuario.UsuarioEmail;
            usuario.Status = 1;
            UsuarioEntity db2 = new UsuarioEntity();
            if (db2.BuscaUsuarioPorLogin(usuario.UsuarioLogin))
            {
                ModelState.AddModelError("usuario.LoginExistente", "Este e-mail já está cadastrado");
            }
            if (ModelState.IsValid)
            {
                UsuarioEntity db = new UsuarioEntity();
                db.Gravar(usuario);

                this.FlashInfo("Usuário cadastrado com sucesso"); //M001
                return RedirectToAction("Index", "Usuario");       
                

            }
            else
            {
                ViewBag.Usuario = usuario;
                UsuarioEntity db = new UsuarioEntity();
                this.FlashError("Erro ao cadastrar usuário"); //M006
                return View("Form");
            }
        }

        public ActionResult Adiciona()
        {
            return View();
        }

        //[Route("produtos/{id}", Name = "VisualizaProduto")]
        [Route("Usuario/VisualizaUsuario/{id}", Name = "VisualizaUsuario")]
        public ActionResult Visualiza(int id)
        {
            UsuarioEntity db = new UsuarioEntity();
            Usuario usuario = db.BuscaUsuarioPorId(id);
            ViewBag.Usuario = usuario;
            return View(usuario);
        }

        //public ActionResult Decrementar(int id)
        //{
        //    UsuarioEntity db = new UsuarioEntity();
        //    Usuario usuario = db.BuscaUsuarioPorId(id);
        //    usuario.UsuarioTipo--;
        //    db.Alterar(usuario);
        //    return Json(usuario);
        //}

        //[Route("usuarios/{id}", Name="VisualizaUsuario")]
        //public ActionResult VisualizaUsuario(int usuarioId)
        //{
        //    UsuarioEntity dao = new UsuarioEntity();
        //    Usuario usuario = dao.BuscaUsuarioPorId(usuarioId);
        //    ViewBag.Usuario = usuario;
        //    return View(usuario);
        //}


        //[Route("usuarios/{id}", Name = "Alterar")]
        public ActionResult Alterar(Usuario usuario)
        {
            UsuarioEntity dao = new UsuarioEntity();               
            if (dao.Alterar(usuario))
            {
                this.FlashInfo("Usuário alterado com sucesso"); //M002
                return RedirectToAction("Index");
            } else {
                this.FlashInfo("Erro ao alterar usuário"); //M003
                return RedirectToAction("Index");
            }
        }

        //[HttpGet]
        [Route("Usuario/BuscarUsuario", Name = "BuscarUsuario")]
        public ActionResult BuscarUsuario(string Pesquisa)
        {
            UsuarioEntity dao = new UsuarioEntity();            
            var listaUsuario = dao.BuscarUsuarioPorNome(Pesquisa);

            EmpresaEntity dbEmpresa = new EmpresaEntity();
            IQueryable<Empresa> empresa = dbEmpresa.Empresas();
            ViewBag.Empresa = empresa;

            return View("index",listaUsuario);
        }


    }
}