using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using projetoRafael.Models;

namespace projetoRafael.Data
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto>options):base(options)
        {
        }

        public DbSet<Produto> Produtos{get;set;}
        public DbSet<Categoria> Categorias{get;set;}
        public DbSet<Produto_Categoria> produto_Categorias{get;set;}



// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//     optionsBuilder.UseMySQL("Server=localhost;Database=db_rovema;Uid=root;Pwd=rsa123");
// }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Produto_Categoria>()
            .HasKey(t => new { t.ProdutoId, t.CategoriaId });
        }
    }
}