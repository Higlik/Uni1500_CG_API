﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CgApi
{
    public partial class TbContasContabeis
    {
        public TbContasContabeis()
        {
            TbEmpresa = new HashSet<TbEmpresa>();
        }

        public int Id { get; set; }
        public decimal? Lucro { get; set; }
        public decimal? Despesas { get; set; }
        public int? FkBanco { get; set; }

        public decimal? Saldo { get; set; }
        public virtual TbBanco FkBancoNavigation { get; set; }
        public virtual ICollection<TbEmpresa> TbEmpresa { get; set; }
    }
}