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

        public IList<Materia> Materias()
        {
            var repo = new ControleRotasContext();            
            return repo.Materias.ToList();
        }
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

        public bool BuscaMateriaPorNome(string nome)
        {
            using (ControleRotasContext db = new ControleRotasContext())
            {
                if (db.Materias.FirstOrDefault(u => u.Nome == nome) != null)
                    return true;
                else
                    return false;
            }
        }
    }
}