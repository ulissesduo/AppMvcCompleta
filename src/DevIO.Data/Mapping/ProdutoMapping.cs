﻿using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Descricao).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Imagem).IsRequired().HasColumnType("varchar(100)");
            builder.ToTable("Produtos");
        }
    }
}