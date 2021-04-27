using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thales_test
{
    public class Negocio
    {
        public static decimal CalcularAnual(decimal salario)
        {
           decimal retorno = 0;

            try
            {
                retorno = salario * 12;

                return retorno;


            }
            catch (Exception ex)
            {
                return retorno;
            }


        }
    }
}