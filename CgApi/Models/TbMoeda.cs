﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CgApi
{
    public partial class TbMoeda
    {
        public TbMoeda()
        {
            TbBanco = new HashSet<TbBanco>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TbBanco> TbBanco { get; set; }
    }
}