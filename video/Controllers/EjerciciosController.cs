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
            
            return View();
        }

        public ActionResult Ejercicio1()
        {
            int[] num = { 5, 1, 7, 3, 8, 4, 10, 11, 12, 9 };
            Array.Sort(num);
            ViewBag.num = num;
            return View();
        }

        public ActionResult Ejercicio2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ejercicio2(string n)
        {
            //int[] array = {1,2,3,5,7,11,13};
            int longitud = Int16.Parse(n);
            if (longitud<=20 && longitud>=0)
            {
                ViewBag.resultado = "correcto";
                int[] array = new int[longitud];
                string cad = "";
                int aux = 2;
                for (int i = 0; i < longitud; i++)
                {
                    array[i] =aux;
                    cad = cad + array[i] + " ";
                    aux=aux+2;
                }
                ViewBag.resultado = cad;
            }
            else
            {
                ViewBag.resultado = "No corresponde al rango de 0 - 20";
            }
            
            return View();
        }
    }
}