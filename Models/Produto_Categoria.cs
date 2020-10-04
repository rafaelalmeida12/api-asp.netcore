
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projetoRafael.Models
{
    public class Produto_Categoria
    {
        public int ProdutoId{get;set;}
        public Produto Produto {get;set;}
        public int CategoriaId{get;set;}
        public Categoria Categoria {get;set;}
    }
}