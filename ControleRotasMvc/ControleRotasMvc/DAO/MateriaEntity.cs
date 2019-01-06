using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class MateriaEntity : DbContext
    {

        public IQueryable<Materia> Materias(string Pesquisa = "")
        {
            ControleRotasContext db = new ControleRotasContext();
            var q = db.Materias.AsQueryable();
            q = q.Where(c => c.Nome.Contains(Pesquisa));
            q.ToList();
            return q;
        }

        //public IList<Materia> Materias()
        //{
        //    var repo = new ControleRotasContext();
        //    return repo.Materias.ToList();
        //}

        public bool Gravar(Materia materia)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Materias.Add(materia);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public Materia BuscaMateriaPorId(int id)
        {
            using (var contexto = new ControleRotasContext())
            {
                return contexto.Materias.Find(id);

            }
        }

        public bool BuscaMateria(string nome)
        {
            using (ControleRotasContext db = new ControleRotasContext())
            {
                if (db.Materias.FirstOrDefault(u => u.Nome == nome) != null)
                    return true;
                else
                    return false;
            }
        }

        public IQueryable<Materia> BuscaMateriaPorNome(string Pesquisa = "")
        {
            ControleRotasContext db = new ControleRotasContext();
            var q = db.Materias.AsQueryable();
            q = q.Where(c => c.Nome.Contains(Pesquisa));
            q.ToList();
            return q;
        }

        public bool Deletar(Materia materia)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Materias.Remove(materia);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch (Exception EX)
            {
                return false;
            }
        }
    }
}