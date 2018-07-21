using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class AlunoEntity : DbContext
    {
        public IList<Aluno> Alunos()
        {
            var repo = new ControleRotasContext();
            return repo.Alunos.ToList();
        }

        public bool Gravar(Aluno aluno)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Alunos.Add(aluno);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch(Exception EX)
            {

                return false;
            }
        }

        public Aluno BuscaAlunoPorId(int id)
        {
            using (var contexto = new ControleRotasContext())
            {
                return contexto.Alunos.Find(id);

            }
        }

        public bool BuscaAlunoPorEmail(string email)
        {
            using (ControleRotasContext db = new ControleRotasContext())
            {
                if (db.Alunos.FirstOrDefault(u => u.Email == email) != null)
                    return true;
                else
                    return false;
            }
        }
    }
}