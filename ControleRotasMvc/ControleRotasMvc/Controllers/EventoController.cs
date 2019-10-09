using ControleRotasMvc.DAO;
using ControleRotasMvc.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleRotasMvc.Controllers
{
    [AutorizacaoFilter]
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (ControleRotasContext db = new ControleRotasContext())
            {
                var events = db.Eventos.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}