using Entidad;
using Logica;
using NUnit.Framework;
using System;

namespace TestBLL
{
    public class TestUsuarioService
    {
        string conecctionString = "";
        UsuarioService service;

        [SetUp]
        public void Setup()
        {
            service = new UsuarioService(conecctionString);
        }

        [Test]
        public void GuardarUsuario_DB()
        {
            var usuario = new Usuario()
            {
                Confirmacion = "Aceptado",
                Contraseña = "Juaz1234f",
                NombreUsuario = "LmEdina"
            };

            var request = service.GuardarUsuario_DB(usuario);

            Assert.AreEqual(request, "Usuario guardado correctamnte");
            
        }
    }
}
