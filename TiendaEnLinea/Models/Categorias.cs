using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        public string Nombre { get; set; }

        public List<Item> Items { get; set; }
    }
}