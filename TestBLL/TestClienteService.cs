using Entidad;
using Logica;
using NUnit.Framework;
using System;

namespace TestBLL
{
    public class TestClienteService
    {
        string conecctionString = "";
        ClienteService service;

        [SetUp]
        public void Setup()
        {
            service = new ClienteService(conecctionString);
        }

        [Test]
        public void TestGuardarVehiculo_DB()
        {
            var cliente = new Cliente()
            {
                Cedula = "10032213",
                Apellido = "Medina",
                Nombre = "Ligia",
                Celular = "3219874560",
                Ciudad = "Valledupar",
                Correo = "lm@gmai.com",
                Direccion = "Var-45 #78",
                Genero = "F"
            };

            var request = service.GuardarVehiculo_DB(cliente);

            Assert.AreEqual(request, "Cliente guardado correctamente");
            
        }
    }
}
