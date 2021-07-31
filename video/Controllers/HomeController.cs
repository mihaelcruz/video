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
    public class HomeController : Controller
    {
        private videoEntities2 db = new videoEntities2();

        public ActionResult Index()
        {
            var peliculas = db.Peliculas.Include(p => p.Categorias);
            return View(peliculas.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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