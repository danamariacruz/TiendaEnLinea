using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.Controllers
{
    public class CarritoController : Controller
    {
        private TiendaDB db = new TiendaDB();

        // GET: Carrito
        public ActionResult Index(int id)
        {
            if (Session["carrito"] == null)
            {
                List<CarritoItem> comprar = new List<CarritoItem>();
                comprar.Add(new CarritoItem(db.productos.Find(id), 1));
                Session["carrito"] = comprar;
            }
            else
            {
                List<CarritoItem> comprar = (List<CarritoItem>)Session["carrito"];
                int existe = getIndex(id);
                if (existe == -1)
                    comprar.Add(new CarritoItem(db.productos.Find(id), 1));
                else comprar[existe].Cantidad++;
                Session["carrito"] = comprar;
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> comprar = (List<CarritoItem>)Session["carrito"];
            comprar.RemoveAt(getIndex(id));
            return View("Index");
        }

        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Items.ProductoID == id)
                    return i;
            }
            return -1;
        }

        public ActionResult Ventas()
        {

            if (Session["carrito"] != null)
            {
                List<CarritoItem> comprar = (List<CarritoItem>)Session["carrito"];
                Ventas NuevaVenta = new Ventas();
                NuevaVenta.DiaVenta = DateTime.Now;
                NuevaVenta.SubTotal = comprar.Sum(x => Convert.ToSingle(x.Items.Precio * x.Cantidad));
                NuevaVenta.Total = Convert.ToSingle(NuevaVenta.SubTotal * 0.16);

                //NuevaVenta.ListaVenta = (from item in comprar
                //                         select new ListaVenta
                //                         {
                //                             Cantidad = item.Cantidad,
                //                             ItemID = item.Items.ProductoID,
                //                             Total = Convert.ToSingle(item.Items.Precio * item.Cantidad)
                //                         }).ToList();

                db.ventas.Add(NuevaVenta);
                db.SaveChanges();
            }
            return View();
        }
    }
}