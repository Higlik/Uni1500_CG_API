﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CgApi
{
    public partial class TbPais
    {
        public TbPais()
        {
            TbCliente = new HashSet<TbCliente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TbCliente> TbCliente { get; set; }
    }
}