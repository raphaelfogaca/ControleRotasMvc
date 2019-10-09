using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }   
        public ActionResult Autentica(String login, String senha)
        {
            UsuarioEntity db = new UsuarioEntity();
            Usuario usuario = db.ValidaUsuario(login, senha);

            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario.UsuarioNome;

                EmpresaEntity db2 = new EmpresaEntity();
                Empresa empresa = new Empresa();
                empresa = db2.BuscaEmpresaPorId(usuario.EmpresaId);

                Session["empresaLogada"] = empresa.Id;
                return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Login");            
        }

        public ActionResult Sair()        {
            Session["usuarioLogado"] = null;
            Session["empresaLogada"] = null;
            return RedirectToAction("Index", "Login");
        }


    }
}