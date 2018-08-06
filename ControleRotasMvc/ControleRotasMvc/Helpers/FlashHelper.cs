using ControleRotasMvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.Helpers
{
    public static class FlashHelper 
    {
            public static void FlashInfo(this UsuarioController controller, string message)
            {
                controller.TempData["info"] = message;
            }
            public static void FlashWarning(this UsuarioController controller, string message)
            {
                controller.TempData["warning"] = message;
            }
            public static void FlashError(this UsuarioController controller, string message)
            {
                controller.TempData["error"] = message;
            }
        
    }
}