
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projetoRafael.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="Este campo é obrigatório")]
        public string Nome  { get; set; }
        [JsonIgnore]
        public IList<Produto> Produtos  { get; set; }
       
    }
}