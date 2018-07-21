using ControleRotasMvc.DAO;
using ControleRotasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    public class MensalidadeController : Controller
    {
        // GET: Mensalidade
        public ActionResult Index()
        {
            return View();
        }

        public Mensalidade Cadastrar(Mensalidade mensalidade, int qtdMaterias)
        {
            MensalidadeEntity db3 = new MensalidadeEntity();
            
            while (qtdMaterias > 0)
            {
                db3.Gravar(mensalidade);
                qtdMaterias--;
                mensalidade.Id = 0;
            }
            return (mensalidade);
        }
    }
}