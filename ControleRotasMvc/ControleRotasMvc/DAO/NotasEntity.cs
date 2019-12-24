using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRotasMvc.DAO
{
    public class NotasEntity : DbContext
    {
        public IList<Nota> Notas()
        {
            var repo = new ControleRotasContext();
            return repo.Notas.ToList();
        }

        public bool Gravar(Nota[] nota)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    int c = nota.Count() - 1;
                    int i = 0;
                    do
                    {
                        Nota nt = new Nota();
                        nt = nota[i];
                        repo.Notas.Add(nt);
                        repo.SaveChanges();
                        i++;
                    } while (i <= c);
                    return true;
                }
            }
            catch (Exception EX)
            {

                return false;
            }
        }

        public bool Alterar(Nota[] nota)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    int c = nota.Count() - 1;
                    int i = 0;
                    do
                    {
                        Nota nt = new Nota();
                        nt = nota[i];

                        //MateriaEntity materias = new MateriaEntity();
                        //Materia materia = new Materia();
                        //materia = materias.BuscaMateriaPorId(nt.MateriaId);
                        //nt.Materia = materia.Nome;

                        repo.Notas.Update(nt);
                        repo.SaveChanges();
                        i++;
                    } while (i <= c);
                    return true;
                }
            }
            catch (Exception EX)
            {
                return false;
            }
        }

        public IQueryable<Nota> BuscarNotaPorAlunoId(int alunoId)
        {
            ControleRotasContext db = new ControleRotasContext();
            var q = db.Notas.AsQueryable();
            q = q.Where(c => c.AlunoId == alunoId);
            q.ToList();
            return q;
        }

        public IList<Nota> BuscarNotaPorAluno(int alunoId)
        {

            var repo = new ControleRotasContext();
            var q = (from f in repo.Notas
                               join a in repo.Materias on f.MateriaId equals a.Id
                               where f.AlunoId == alunoId
                               select new
                               {
                                   f,
                                   a
                               }).ToList();

            return q.Select(n => new Nota()
            {
                Materia = n.a.Nome,
                Id = n.f.Id,
                AlunoId = n.f.AlunoId,
                //ValorNota = n.f.ValorNota,
                //Bimestre = n.f.Bimestre

            }).ToList();
        }


    }
}