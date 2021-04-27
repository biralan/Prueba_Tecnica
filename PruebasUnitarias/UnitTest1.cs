using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Thales_test;
using System.Web;
using Newtonsoft.Json;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaMetodoEmpleadoByID()
        {

            //arrange
            decimal sueldo = 5;
            decimal resultadoEsperado = sueldo*12;
            //act

            var result = Negocio.CalcularAnual(sueldo);

            //assert
            Assert.AreEqual(resultadoEsperado, result);
        }
    }
}
