using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleRotasMvc.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ControleRotasMvc.DAO
{
    public class UsuarioEntity : DbContext, IDisposable
    {
        public bool Gravar(Usuario usuario)
        {
            try
            {
                using (var repo = new ControleRotasContext())
                {
                    repo.Usuarios.Add(usuario);
                    repo.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public IList<Usuario> Usuarios()
        {
            var repo = new ControleRotasContext();
            return repo.Usuarios.ToList();
        }

        public Usuario ValidaUsuario(string login, string senha)
        {
            using (var db = new ControleRotasContext())
            {
                return db.Usuarios.Where(o => o.UsuarioLogin == login && o.UsuarioSenha == senha).FirstOrDefault();               
            }
        }

        public Usuario VerificaUsuario(string login, string senha)
        {
            using (ControleRotasContext db = new ControleRotasContext())
            {
                return db.Usuarios.FirstOrDefault(u => u.UsuarioLogin == login && u.UsuarioSenha == senha);
            }  
        }

        public Usuario BuscaUsuarioPorId(int id)
        {
            using (var contexto = new ControleRotasContext())
            {
                return contexto.Usuarios.Find(id);
                    
            }
        }

        public bool BuscaUsuarioPorLogin(string login)
        {
            using (ControleRotasContext db = new ControleRotasContext())
            {
                if (db.Usuarios.FirstOrDefault(u => u.UsuarioLogin == login) != null)
                    return true;
                else
                    return false;
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var contexto = new ControleRotasContext())
            {
                contexto.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                contexto.SaveChanges();              
            }
        }     
    }
}