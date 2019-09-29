﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleRotasMvc;
using ControleRotasMvc.Models;

namespace ControleRotasMvc.DAO

{
    public class ControleRotasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaAlunos> MateriaAlunos { get; set; }
        public DbSet<Financeiro> DocumentosFinanceiros { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<DiasAula> DiasAula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Larissa\Documents\ControleRotasDB.mdf;Integrated Security=True;Connect Timeout=30");

            // optionsBuilder.UseSqlServer("Server=tcp:fogacadb.database.windows.net,1433;Initial Catalog=VistoDB;" +
            //"Persist Security Info=False;User ID=spwrei;Password=dslink123#;" +
            //"MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
