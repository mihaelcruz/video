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
            if (longitud<=50 && longitud>=0)
            {
                ViewBag.resultado = "correcto";
                int[] array = new int[longitud+1];
                string cad = "";
                int pares = 2;
                int multiplos = 3;

                for (int i = 1; i <= longitud; i++)
                {
                    if (i % 2 == 0)
                    {
                        array[i] = multiplos;
                        multiplos = multiplos + 3;
                    }
                    else {

                        array[i] = pares;
                        pares = pares + 2;
                        
                    }
                    cad = cad + array[i] + " ";
                }
                ViewBag.resultado = cad;
            }
            else
            {
                ViewBag.resultado = "No corresponde al rango de 0 - 20";
            }
            
            return View();
        }

        public ActionResult Ejercicio3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ejercicio3(string n)
        {
            int num = Int16.Parse(n);
            string tabla="";
            if (num <= 10 && num >= 1)
            {
                for (int i = 1; i <= 10; i++)
                { 
                    tabla = tabla + "<tr><td>" + num + "</td><td>x</td><td>" + i + "</td><td>" + num * i + "</td></tr>";
                }
                ViewBag.tabla = "<table border='1'>"+tabla+"</table>";
            }
            else {
                ViewBag.tabla = "No corresponde al rango";
            }
                return View();
        }



    }
}