using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thales_test.Models;
using AutoMapper;
using Newtonsoft.Json;
using System.IO;
using Thales_test;

namespace Thales_test.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("ListarEmpleados")]
        public IEnumerable<Empleados> ListarEmpleados()
        {
            
            
            var lst = new List<Empleados>();
                var url = $"http://dummy.restapiexample.com/api/v1/employees";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        //if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                        INFO lstmt = JsonConvert.DeserializeObject<INFO>(responseBody);

                        lstmt.data.ForEach(m=> lst.Add(new Empleados() 
                        {
                            id=m.id,
                            employee_name=m.employee_name,
                            employee_salary=m.employee_salary,
                            employee_age=m.employee_age,
                            profile_image = m.profile_image,
                            Employee_anual_salary= Negocio.CalcularAnual(m.employee_salary)
                        }));
                        }
                    }
                }

            
            return lst;
        }

        [HttpGet]
        [Route("ListarEmpleadosbyID")]
        public IEnumerable<Empleados> ListarEmpleadosbyID(string id)
        {

            var lst = new List<Empleados>();
            var url = $"http://dummy.restapiexample.com/api/v1/employee/" + id;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    //if (strReader == null) return;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        INFOS lstmt = JsonConvert.DeserializeObject<INFOS>(responseBody);
                        lst.Add(new Empleados()
                        {
                            id = lstmt.data.id,
                            employee_name = lstmt.data.employee_name,
                            employee_salary = lstmt.data.employee_salary,
                            employee_age = lstmt.data.employee_age,
                            profile_image = lstmt.data.profile_image,
                            Employee_anual_salary = lstmt.data.employee_salary * 12
                        });
                    }
                }
            }


            return lst;
        }
    }
}
