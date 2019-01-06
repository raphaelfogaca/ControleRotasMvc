using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class EventoEntity : DbContext
    {
        public List<Evento> Eventos()
        {
            ControleRotasContext db = new ControleRotasContext();
            return db.Eventos.ToList();
        }
    }
}