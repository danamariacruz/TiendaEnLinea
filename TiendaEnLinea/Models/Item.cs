using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class Item
    {
        [Key]
        public int ProductoID { get; set; }
        public int CategoriaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
        
        public string ImagenUrl { get; set; }

        public virtual Categorias categoria { get; set; }
        
        public virtual Producer producer { get; set;  }
    }
}