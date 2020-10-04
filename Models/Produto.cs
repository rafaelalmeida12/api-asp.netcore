using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projetoRafael.Models
{
    public class Produto{

        public int Id { get; set; }
        
        [Required(ErrorMessage="Este campo é obrigatório")]
        public string Nome  { get; set; }

        public decimal Preco  { get; set; }
        
        [Required(ErrorMessage="Este campo é obrigatório")]
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria Categoria  { get; set; }
    }
}