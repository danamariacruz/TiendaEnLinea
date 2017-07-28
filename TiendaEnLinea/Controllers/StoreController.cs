using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaEnLinea.Models;

namespace Tienda.Controllers
{
    public class StoreController : Controller
    {
        TiendaDB db = new TiendaDB();
        
        //metodo que devuelve la lista de categoria
        public ActionResult Index()
        {
            var result = db.Categorias.ToList();

            return View(result);
        }

        
        public ActionResult Buscar(string Categoria)
        {
            var Category = db.Categorias.Include("Items")
                .Single(c => c.Nombre == Categoria);
            return View(Category);
        }

        // devuelve los detalles de los items
        public ActionResult Details(int id)
        {
            var item = db.productos.Include("Categoria").Where(x => x.ProductoID == id).FirstOrDefault();
            
            return View(item);
        }

       
    }
}