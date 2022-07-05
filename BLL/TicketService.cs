using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TicketService
    {
        TicketRepository ticketRepository;
        public ConexionManeger Conection;

        public TicketService(string conection)
        {
            Conection = new ConexionManeger(conection);
            ticketRepository = new TicketRepository(Conection);
        }

        //CONEXION A BASE DE DATOS

        public string GuardarTicket_DB(Ticket ticket)
        {
            try
            {
                Conection.Open();
                ticketRepository.B_GuardarTicket(ticket);
                return "Ticket guardado correctamnte";
            }
            catch (Exception e)
            {
                return $"Error en la aplicación: {e.Message}";
            }
            finally
            {
                Conection.Close();
            }
        }

        public class ConsultaReponse1
        {
            public List<Ticket> Tickets { get; set; }
            public string Mensaje { get; set; }


            public bool Error { get; set; }
            public ConsultaReponse1(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public ConsultaReponse1(List<Ticket> tickets)
            {
                Tickets = tickets;
                Error = false;
            }
        }

        public ConsultaReponse1 ConsultarTickets_DB()
        {

            try
            {
                Conection.Open();
                return new ConsultaReponse1(ticketRepository.B_ConsultarTicket().ToList());
            }
            catch (Exception e)
            {
                return new ConsultaReponse1($"Error, {e.Message}");
            }
            finally
            {
                Conection.Close();
            }
        }

        public string B_ActualizarTicket(Ticket ticket)
        {
            try
            {
                Conection.Open();
                ticketRepository.B_ActualizarTicket(ticket);
                return "Ticket actualizado correctamnte";
            }
            catch (Exception e)
            {
                return $"Error en la aplicación: {e.Message}";
            }
            finally
            {
                Conection.Close();
            }
        }

        public string B_EliminarTicket(string id)
        {
            try
            {
                Conection.Open();
                ticketRepository.B_EliminarTicket(id);
                return "Ticket eliminado correctamnte";
            }
            catch (Exception e)
            {
                return $"Error en la aplicación: {e.Message}";
            }
            finally
            {
                Conection.Close();
            }
        }










    }
}
