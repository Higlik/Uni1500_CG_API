﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CgApi
{
    public partial class TbFuncionario
    {
        public TbFuncionario()
        {
            TbProjeto = new HashSet<TbProjeto>();
        }

        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int? Cpf { get; set; }
        public int? FkEmpresa { get; set; }

        public virtual TbEmpresa FkEmpresaNavigation { get; set; }
        public virtual ICollection<TbProjeto> TbProjeto { get; set; }
    }
}