using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace video.Controllers
{
    public class EjerciciosController : Controller
    {
        // GET: Ejercicios
        public ActionResult Index()
        {
            int[] num = {5, 1, 7, 3,8,4,10,11,12,9};
            Array.Sort(num);
            ViewBag.num=num;
            return View();
        }
    }
}