using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach(var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))) 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);//register each mappings at the same time

            //remove delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            base.OnModelCreating(modelBuilder);
        }
    }
}
