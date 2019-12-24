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
        //public IList<Aluno> Alunos()
        //{
        //    var repo = new ControleRotasContext();
        //    return repo.Alunos.ToList();
        //}

        public IQueryable<Aluno> Alunos(string Pesquisa = "")
        {
            //var repo = new ControleRotasContext();
            //return repo.Usuarios.ToList();

            ControleRotasContext db = new ControleRotasContext();
            var q = db.Alunos.AsQueryable();
            q = q.Where(c => c.Nome.Contains(Pesquisa));
            q.ToList();
            return q;
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

        public IQueryable<Aluno> BuscarAlunoPorNome(string nome)
        {
            ControleRotasContext db = new ControleRotasContext();
            var q = db.Alunos.AsQueryable();
            q = q.Where(c => c.Nome.Contains(nome));
            q.ToList();
            return q;
        }

        public string Alterar(Aluno aluno)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Alunos.Update(aluno);
                    repo.SaveChanges();
                    return "OK";
                }
            }
            catch (Exception EX)
            {                
                string erro = "" + EX.InnerException.Message;
                return erro;
            }
        }
    }
}