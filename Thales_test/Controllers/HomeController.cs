using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thales_test.Models;
using static Thales_test.MvcApplication;

namespace Thales_test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        #region Buscador Empleados
        public ActionResult BuscadorEmpleados()
        {
            return View();
        }
        public async Task<ActionResult> ListarEmpleados(decimal id=0)
        {
            var Rpta = new Respuesta() { Mensaje = "No se encontro información", Objeto = new List<Empleados>() };
            var accion = string.Empty;
            try
            {
                var urlwebapi = GLOBALES.API;
                if (id==0)
                {
                    accion = urlwebapi + "Values/ListarEmpleados";
                }
                else
                {
                    accion = urlwebapi + "Values/ListarEmpleadosbyID?id="+ id;
                }                
                var htppCiente = new HttpClient();
                var rpta = await htppCiente.GetStringAsync(accion);
                var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Empleados>>(rpta);
                if (lst.Count>0)
                {
                    Rpta.Objeto = lst;
                    Rpta.Estado = true;
                    Rpta.Mensaje = "Se encontro informacion";
                }

            }
            catch (Exception ex)
            {
                string texto = ex.Message + " " + ex.Source + " " + ex.StackTrace + " " + ex.InnerException;
                Rpta.Mensaje = texto;
            }
            return _Json.Result(Rpta);
        }
        #endregion
    }
}