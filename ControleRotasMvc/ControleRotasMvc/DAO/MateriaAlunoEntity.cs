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
        public bool Gravar(IEnumerable<MateriaAlunos> materia, Aluno aluno)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    foreach (var item in materia)
                        {
                            item.AlunoId = aluno.Id;                        
                        };
                    repo.MateriaAlunos.AddRange(materia);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch (Exception EX)
            {
                return false;
            }
        }

        public MateriaAlunos BuscaMateriaPorAlunoId(int alunoId)
        {
            using (ControleRotasContext db = new ControleRotasContext())
            {
                return db.MateriaAlunos.LastOrDefault(u => u.AlunoId == alunoId);              
                   
            }
        }
    }
}