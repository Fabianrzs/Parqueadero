using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TicketRepository
    {
        public ConexionManeger conexion;
        public SqlDataReader reader;
        static List<Ticket> tickets = new List<Ticket>();

        public TicketRepository(ConexionManeger conexion)
        {
            this.conexion = conexion;
            tickets = new List<Ticket>();
        }

        //CONEXION A BASE

        public void B_GuardarTicket(Ticket ticket)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "GuardarTicket";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = ticket.Id;
                command.Parameters.Add("@fecha", SqlDbType.VarChar).Value = ticket.Fecha;
                command.Parameters.Add("@horaEntrada", SqlDbType.VarChar).Value = ticket.HoraEntrada;
                command.Parameters.Add("@horaSalida", SqlDbType.VarChar).Value = ticket.HoraSalida;
                command.Parameters.Add("@Cedula", SqlDbType.VarChar).Value = ticket.Cedula1;
                command.Parameters.Add("@placa", SqlDbType.VarChar).Value = ticket.Placa;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = ticket.Nombre;
                command.Parameters.Add("@tipoVehiculo", SqlDbType.VarChar).Value = ticket.TipoVehiculo;
                command.ExecuteNonQuery();
            }
        }

        public IList<Ticket> B_ConsultarTicket()
        {
            tickets.Clear();
            using (var comand = conexion.Connection.CreateCommand())
            {
                comand.CommandText = "select * from ticket";
                reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Ticket ticket;
                    ticket = MapearTicketBD(reader);
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }

        public Ticket MapearTicketBD(SqlDataReader reader)
        {
            Ticket ticket = new Ticket();
            ticket.Id = (string)reader["id"];
            ticket.Fecha = (string)reader["fecha"];
            ticket.HoraEntrada = (string)reader["horaEntrada"];
            ticket.HoraSalida = (string)reader["horaSalida"];
            ticket.Cedula1 = (string)reader["Cedula"];
            ticket.Placa = (string)reader["placa"];
            ticket.Nombre = (string)reader["nombre"];
            ticket.TipoVehiculo = (string)reader["tipovehiculo"];
            return ticket;
        }

        public void B_ActualizarTicket(Ticket ticket)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "ModificarTicket";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = ticket.Id;
                command.Parameters.Add("@fecha", SqlDbType.VarChar).Value = ticket.Fecha;
                command.Parameters.Add("@horaEntrada", SqlDbType.VarChar).Value = ticket.HoraEntrada;
                command.Parameters.Add("@horaSalida", SqlDbType.VarChar).Value = ticket.HoraSalida;
                command.Parameters.Add("@Cedula", SqlDbType.VarChar).Value = ticket.Cedula1;
                command.Parameters.Add("@placa", SqlDbType.VarChar).Value = ticket.Placa;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = ticket.Nombre;
                command.Parameters.Add("@tipoVehiculo", SqlDbType.VarChar).Value = ticket.TipoVehiculo;
                command.ExecuteNonQuery();
            }
        }

        public void B_EliminarTicket(string id)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "EliminarTicket";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();
            }
        }

       









    }
}
