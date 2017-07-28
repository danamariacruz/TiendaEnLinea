using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class Producer
    {
        [Key]
        public int ProducerID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public virtual Categorias CategoriaID { get; set; }

        
    }
}