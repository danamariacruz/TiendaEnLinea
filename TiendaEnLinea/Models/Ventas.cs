using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class Ventas
    {

        [Key]
        public int VentaID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DiaVenta { get; set; }

        public float SubTotal { get; set; }

        public float Total { get; set; } 

    }
}