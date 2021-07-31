using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using video.Data;

namespace video.Controllers
{
    public class PeliculasController : Controller
    {
        private videoEntities2 db = new videoEntities2();

        // GET: Peliculas
        public ActionResult Index()
        {
            var peliculas = db.Peliculas.Include(p => p.Categorias);
            return View(peliculas.ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.Peliculas.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            return View(peliculas);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "nombre");
            return View();
        }

        // POST: Peliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,Codigo,Descripcion,CategoriaId,imagen")] Peliculas peliculas)
        {
            /*IMAGEN*/
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);
            peliculas.imagen = image.GetBytes();

            if (ModelState.IsValid)
            {
                db.Peliculas.Add(peliculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "nombre", peliculas.CategoriaId);
            return View(peliculas);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.Peliculas.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "nombre", peliculas.CategoriaId);
            return View(peliculas);
        }

        // POST: Peliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,Codigo,Descripcion,CategoriaId,imagen")] Peliculas peliculas)
        {
            /*IMAGEN*/
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);
            peliculas.imagen = image.GetBytes();

            if (ModelState.IsValid)
            {
                db.Entry(peliculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "Id", "nombre", peliculas.CategoriaId);
            return View(peliculas);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.Peliculas.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            return View(peliculas);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peliculas peliculas = db.Peliculas.Find(id);
            db.Peliculas.Remove(peliculas);
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

        public ActionResult getImage(int id)
        {
            Peliculas peliculas = db.Peliculas.Find(id); //select * from peliculas where id= id
            byte[] byteImage = peliculas.imagen;
            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;
            return File(memoryStream, "image/jpg");
        }

    }
}
