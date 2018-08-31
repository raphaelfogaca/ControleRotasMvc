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

        public Nota[] Cadastrar(Nota[] nota)
        {
            int qtdNotas = nota.Count();
            int i = 0;
            NotasEntity db = new NotasEntity();
            while (qtdNotas > 0) { 
            db.Gravar(nota[i]);
                qtdNotas--;
                i++;
            }
            return nota;
            
        }
    }
}