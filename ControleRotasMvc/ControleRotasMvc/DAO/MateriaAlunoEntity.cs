using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class MateriaAlunoEntity : DbContext
    {
        public bool Gravar(MateriaAlunos materia)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.MateriaAlunos.Add(materia);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}