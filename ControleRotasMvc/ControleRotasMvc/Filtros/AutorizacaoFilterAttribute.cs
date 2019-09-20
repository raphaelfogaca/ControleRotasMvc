using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControleRotasMvc.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            // se usuario for nulo (nao logado) envia para um actionresult
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                 new RouteValueDictionary(
                     new { controller = "Login", action = "Index"}
                     ));
            }
        }

        public void OnAuthentication(AuthorizationContext filterContext)
        {
            throw new NotImplementedException();
        }
    }    
}