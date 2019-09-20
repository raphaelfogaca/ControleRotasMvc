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
    }
}