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
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Login");            
        }
    }
}