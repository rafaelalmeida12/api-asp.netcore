using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoRafael.Data;
using projetoRafael.Models;

namespace projetoRafael.Controllers
{
    [ApiController]
    [Route("v1/Categoria")]
    public class CategoriaController:ControllerBase
    {
        ///<summary>
        /// Listar Categorias
        ///</summary>
        ///<response code="200"> Categorias sucesso.</response>
        [HttpGet]
        [Route("")]
        public IActionResult Index([FromServices]Contexto context)
        {
            try
            {
                var produto = context.Categorias.ToList();
                return  Ok(produto);
            }
            catch(Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);    
            }
        }
       
       ///<summary>
       /// Adicionar Nova Categoria
       ///</summary>
       ///<response code="200"> Categoria adicionado com sucesso.</response>
        [HttpPost]
        [Route("")]
        public IActionResult Adicionar([FromServices]Contexto context,[FromBody] Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return Ok(categoria);
            }
            else
            {
                return BadRequest(new {mensagem="erro ao adicionar categoria"+ categoria});
            }
        }

       ///<summary>
       /// Buscar Categoria por ID
       ///</summary>
       ///<response code="200"> Categoria  sucesso.</response>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult BuscarPorId([FromServices]Contexto context,int id)
        {
            var categoria = context.Categorias
            .FirstOrDefault(c=>c.Id==id);
            return  Ok(categoria);
        } 

       ///<summary>
       /// Alterar Categoria
       ///</summary>
       ///<response code="200"> Categoria alterada com sucesso.</response>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Alterar([FromServices]Contexto context,[FromBody] Categoria categoria,int id)
        {
             var categoriaBanco = context.Categorias
            .FirstOrDefault(c=>c.Id==id);

            if(categoriaBanco == null)
               return NotFound(new {mensagem="Categoria não encontrado."});
           
           categoriaBanco.Nome=categoria.Nome;
           context.Categorias.Update(categoriaBanco); 
           context.SaveChanges();
           
            return  Ok(categoriaBanco);
        }

        ///<summary>
       /// Excluir Categoria
       ///</summary>
       ///<response code="200"> Categoria excluido com sucesso.</response>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Deletar([FromServices]Contexto context,int id)
        {
            var categoria = context.Categorias
               .FirstOrDefault(c=>c.Id==id); 
            
             var produtos = context.Produtos.Include(c=>c.Categoria)
                .Where(c=>c.CategoriaId==id)
                .ToList();

                if(produtos.Count!=0)
                {
                   return NotFound(new {mensagem="voce nao pode excluir uma categoria que possui produto"});
                }
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            
            return  Ok(categoria);
        }
    }

}