﻿// <auto-generated />
using ControleRotasMvc.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ControleRotasMvc.Migrations
{
    [DbContext(typeof(ControleRotasContext))]
    [Migration("20180816010346_NotaeAluno")]
    partial class NotaeAluno
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleRotasMvc.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AulaDomingo");

                    b.Property<int>("AulaQuarta");

                    b.Property<int>("AulaQuinta");

                    b.Property<int>("AulaSabado");

                    b.Property<int>("AulaSegunda");

                    b.Property<int>("AulaSexta");

                    b.Property<int>("AulaTerca");

                    b.Property<string>("Email");

                    b.Property<string>("EmailResponsavel");

                    b.Property<string>("Nome");

                    b.Property<string>("NomeResponsavel");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ControleRotasMvc.Models.Financeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlunoId");

                    b.Property<int>("Situacao");

                    b.Property<float>("Valor");

                    b.Property<DateTime>("Vencimento");

                    b.HasKey("Id");

                    b.ToTable("DocumentosFinanceiros");
                });

            modelBuilder.Entity("ControleRotasMvc.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("ControleRotasMvc.Models.MateriaAlunos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlunoId");

                    b.Property<int>("MateriaId");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("MateriaAlunos");
                });

            modelBuilder.Entity("ControleRotasMvc.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlunoId");

                    b.Property<int>("Bimestre");

                    b.Property<int>("MateriaId");

                    b.Property<float>("ValorNota");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("ControleRotasMvc.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<string>("UsuarioEmail");

                    b.Property<string>("UsuarioLogin");

                    b.Property<string>("UsuarioNome");

                    b.Property<string>("UsuarioSenha");

                    b.Property<string>("UsuarioSobrenome");

                    b.Property<int>("UsuarioTipo");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ControleRotasMvc.Models.MateriaAlunos", b =>
                {
                    b.HasOne("ControleRotasMvc.Models.Aluno", "Aluno")
                        .WithMany("MateriaAlunos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleRotasMvc.Models.Materia", "Materia")
                        .WithMany("MateriaAlunos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleRotasMvc.Models.Nota", b =>
                {
                    b.HasOne("ControleRotasMvc.Models.Aluno", "Aluno")
                        .WithMany("Notas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleRotasMvc.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
