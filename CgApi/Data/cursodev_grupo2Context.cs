﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using CgApi.Models;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CgApi
{
    public partial class cursodev_grupo2Context:IdentityDbContext<ApplicationUser>
{
    
        public cursodev_grupo2Context(DbContextOptions<cursodev_grupo2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TbBanco> TbBanco { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbContasContabeis> TbContasContabeis { get; set; }
        public virtual DbSet<TbFluxoCaixa> TbFluxoCaixas { get; set; }
        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }
        public virtual DbSet<TbMoeda> TbMoeda { get; set; }
        public virtual DbSet<TbPais> TbPais { get; set; }
        public virtual DbSet<TbProjeto> TbProjeto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TbBanco>(entity =>
            {
                entity.ToTable("Tb_Banco");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FkMoeda).HasColumnName("FK_Moeda");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TpConta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Tp_Conta");

                entity.HasOne(d => d.FkMoedaNavigation)
                    .WithMany(p => p.TbBanco)
                    .HasForeignKey(d => d.FkMoeda)
                    .HasConstraintName("FK__Tb_Banco__FK_Moe__31EC6D26");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Tb_Clien__C1F897300AE41B7B");

                entity.ToTable("Tb_Cliente");

                entity.Property(e => e.Cpf)
                    .ValueGeneratedNever()
                    .HasColumnName("CPF");

                entity.Property(e => e.FkPais).HasColumnName("FK_Pais");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.HasOne(d => d.FkPaisNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.FkPais)
                    .HasConstraintName("FK__Tb_Client__FK_Pa__3C69FB99");
            });

            modelBuilder.Entity<TbContasContabeis>(entity =>
            {
                entity.ToTable("Tb_Contas_Contabeis");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Despesas).HasColumnType("money");

                entity.Property(e => e.FkBanco).HasColumnName("FK_Banco");

                entity.Property(e => e.Lucro).HasColumnType("money");

                entity.HasOne(d => d.FkBancoNavigation)
                    .WithMany(p => p.TbContasContabeis)
                    .HasForeignKey(d => d.FkBanco)
                    .HasConstraintName("FK__Tb_Contas__FK_Ba__34C8D9D1");
            });

            modelBuilder.Entity<TbEmpresa>(entity =>
            {
                entity.ToTable("Tb_Empresa");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkContasContabeis).HasColumnName("FK_Contas_Contabeis");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkContasContabeisNavigation)
                    .WithOne(p => p.TbEmpresa)
                    .HasForeignKey<TbContasContabeis>(d => d.FkEmpresa);
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("PK__Tb_Funci__0FB9FB4E569A671E");

                entity.ToTable("Tb_Funcionario");

                entity.Property(e => e.Matricula).ValueGeneratedNever();

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.FkEmpresa).HasColumnName("FK_Empresa");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkEmpresaNavigation)
                    .WithMany(p => p.TbFuncionario)
                    .HasForeignKey(d => d.FkEmpresa)
                    .HasConstraintName("FK__Tb_Funcio__FK_Em__3F466844");
            });

            modelBuilder.Entity<TbMoeda>(entity =>
            {
                entity.ToTable("Tb_Moeda");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPais>(entity =>
            {
                entity.ToTable("Tb_Pais");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbProjeto>(entity =>
            {
                entity.ToTable("Tb_Projeto");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.FkCliente).HasColumnName("FK_Cliente");

                entity.Property(e => e.FkFuncionario).HasColumnName("FK_Funcionario");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkClienteNavigation)
                    .WithMany(p => p.TbProjeto)
                    .HasForeignKey(d => d.FkCliente)
                    .HasConstraintName("FK__Tb_Projet__FK_Cl__4222D4EF");

                entity.HasOne(d => d.FkFuncionarioNavigation)
                    .WithMany(p => p.TbProjeto)
                    .HasForeignKey(d => d.FkFuncionario)
                    .HasConstraintName("FK__Tb_Projet__FK_Fu__4316F928");
            });

            modelBuilder.Entity<TbFluxoCaixa>(entity =>
            {

                entity.HasOne(d => d.ContaContabil)
                    .WithMany(p => p.FluxoCaixa)
                    .HasForeignKey(d => d.IdContaContabil);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}