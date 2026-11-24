using Microsoft.EntityFrameworkCore;
using AulaApp1.Components.Models;

namespace AulaApp1.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {}

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Produto>( x => 
            { 
                x.Property(y => y.Preco).HasPrecision(10, 2);

            });          
        }
    }
}