using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.Models
{
    public class ListaVenta
    {
        [Key]
        public int ID { get; set; }

        public int VentaId { get; set; }

        public int ItemID { get; set; }

        public virtual Ventas IdVentas { get; set; }

        public virtual Item itemID { get; set; }

        public int Cantidad { get; set; }

        public float Total { get; set; }
    }
}