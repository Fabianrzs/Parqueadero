using Entidad;
using Logica;
using NUnit.Framework;
using System;

namespace TestBLL
{
    public class TestEstacionamientoService
    {
        string conecctionString = "";
        EstacionamientoService service;

        [SetUp]
        public void Setup()
        {
            service = new EstacionamientoService(conecctionString);
        }

        [Test]
        public void GuardarEstacionamiento_DB()
        {
            var estacionamiento = new Estacionamiento()
            {
                Capacidad = "2",
                Codigo = "005FA",
                TipoEstacionamiento = "Preferencial"
            };

            var request = service.GuardarEstacionamiento_DB(estacionamiento);

            Assert.AreEqual(request, "Estacionamiento guardado correctamnte");
            
        }
    }
}
