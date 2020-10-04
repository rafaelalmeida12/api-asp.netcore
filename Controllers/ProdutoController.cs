using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoRafael.Data;
using projetoRafael.Models;

namespace projetoRafael.Controllers
{
    [ApiController]
    [Route("v1/produto")]
    public class ProdutoController:ControllerBase
    {
         ///<summary>
        /// Listar Produtos
        ///</summary>
        ///<response code="200"> Produtos sucesso.</response>
        [HttpGet]
        [Route("")]
        public IActionResult Index([FromServices]Contexto context)
        {
            var produto = context.Produtos.Include(c=>c.Categoria).ToList();
            return  Ok(produto);
        }
       
       ///<summary>
       /// Adicionar Novo Produto
       ///</summary>
       ///<response code="200"> Produto adicionado com sucesso.</response>
        [HttpPost]
        [Route("")]
        public IActionResult Adicionar([FromServices]Contexto context,[FromBody] Produto produto)
        {
            if(ModelState.IsValid)
            {
               // if(categoriaExiste)

                context.Produtos.Add(produto);
                context.SaveChanges();
                return Ok(produto);
            }
            else
            {
                return BadRequest();
            }
        }
         ///<summary>
       /// Buscar Produto por ID
       ///</summary>
       ///<response code="200"> Produto  sucesso.</response>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult BuscarPorId([FromServices]Contexto context,int id)
        {
            var produto = context.Produtos.Include(c=>c.Categoria)
            .AsNoTracking()
            .FirstOrDefault(c=>c.Id==id);
            return  Ok(produto);
        } 
             ///<summary>
       /// Buscar Produto por Categoria ID
       ///</summary>
       ///<response code="200"> Produto  sucesso.</response>
        [HttpGet]
        [Route("categorias/{id:int}")]
        public IActionResult BuscarPorCategoriaId([FromServices]Contexto context,int id)
        {
            var produtos = context.Produtos.Include(c=>c.Categoria)
            .Where(c=>c.CategoriaId==id)
            .ToList();
            return  Ok(produtos);
        } 
       ///<summary>
       /// Alterar Produto
       ///</summary>
       ///<response code="200"> Produto alterado com sucesso.</response>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Alterar([FromServices]Contexto context,int id)
        {
            var produto = context.Produtos.Include(c=>c.Categoria).ToList();
            return  Ok(produto);
        } 
        ///<summary>
       /// Excluir Produto
       ///</summary>
       ///<response code="200"> Produto excluido com sucesso.</response>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Deletar([FromServices]Contexto context,int id)
        {
            var produto = context.Produtos.Include(c=>c.Categoria).ToList();
            return  Ok(produto);
        }
    }

}