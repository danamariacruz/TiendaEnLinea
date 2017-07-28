using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using TiendaEnLinea.Models;


namespace TiendaEnLinea.Controllers
{
    public class ManageStoreController : Controller
    {
        private TiendaDB db = new TiendaDB();
        // GET: ManageStore
        public ActionResult Index()
        {
            var items = db.productos.Include(i => i.categoria).Include(i => i.producer);
            return View(items.ToList());
        }

        // GET: ManageStore/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item items = db.productos.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // GET: ManageStore/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaID", "Nombre");
            ViewBag.ProductorId = new SelectList(db.marcas, "ProducerId", "Nombre");
            return View();
        }

        // POST: ManageStore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CategoriaId,ProductorId,Titulo,Precio,ItemArtUrl")] Item items)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", items.CategoriaId);
            ViewBag.ProductorId = new SelectList(db.marcas, "ProducerID", "Nombre", items.ProductoID);
            return View(items);
        }

        // GET: ManageStore/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item items = db.productos.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", items.CategoriaId);
            ViewBag.ProductorId = new SelectList(db.marcas, "ProducerID", "Nombre", items.ProductoID);
            return View(items);
        }

        // POST: ManageStore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CategoriaId,ProductorId,Titulo,Precio,ItemArtUrl")] Item items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", items.CategoriaId);
            ViewBag.ProductorId = new SelectList(db.marcas, "ProducerID", "Nombre", items.ProductoID);
            return View(items);
        }

        // GET: ManageStore/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item items = db.productos.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: ManageStore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item items = db.productos.Find(id);
            db.productos.Remove(items);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
