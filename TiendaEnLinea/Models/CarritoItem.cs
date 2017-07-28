using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.Models
{
    public class CarritoItem
    {
        private Item _items;
        private int _cantidad;

        //public Item Items { get => _items; set => _items = value; }
        //public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public Item Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public CarritoItem()
        {

        }

        public CarritoItem(Item items, int cantidad)
        {
            this.Items = items;
            this.Cantidad = cantidad;
        }
    }
}