using Entidad;
using Logica;
using NUnit.Framework;
using System;

namespace TestBLL
{
    public class TestTicketService
    {
        string conecctionString = "";
        TicketService service;

        [SetUp]
        public void Setup()
        {
            service = new TicketService(conecctionString);
        }

        [Test]
        public void GuardarTicket_DB()
        {
            var ticket = new Ticket()
            {
                Cedula1 = "12545966",
                Fecha = "06/16/2003",
                HoraEntrada = "12:00 pm",
                HoraSalida = "14:00 pm",
                Id = "4567",
                Nombre = "Ligia",
                Placa = "qwe-123",
                TipoVehiculo = "Moto"
            };

            var request = service.GuardarTicket_DB(ticket);
            Assert.AreEqual(request, "Ticket guardado correctamnte"); 
        }
    }
}
