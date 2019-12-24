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

        public Evento AdicionarEvento(Evento evento)
        {
            var db = new ControleRotasContext();
            db.Eventos.Add(evento);
            db.SaveChanges();
            return evento;
        }
    }
}