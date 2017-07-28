using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.Models
{
    public class TiendaDB: DbContext
    {
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Producer> marcas { get; set; }
        public DbSet<Item> productos { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<ListaVenta> listaVenta { get; set; }

    }
}