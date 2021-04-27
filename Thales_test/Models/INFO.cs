using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales_test.Models
{
    public class INFO
    {
        public string status { get; set; }
        public List<Empleados> data { get; set; }
        public string message { get; set; }
    }
}