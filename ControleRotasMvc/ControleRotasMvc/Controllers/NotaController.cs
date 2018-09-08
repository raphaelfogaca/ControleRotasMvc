using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    public class NotaController : Controller
    {
        // GET: Nota
        public ActionResult Index()
        {
            return View();
        }

        public Nota Cadastrar(Nota[] nota)
        {
           
            NotasEntity db = new NotasEntity();
            
            db.Gravar(nota);
            return nota[0];
        }

        
    }
}