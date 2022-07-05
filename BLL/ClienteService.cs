using System;
using Entidad;
using System.Collections.Generic;
using Datos;
using System.Data.SqlClient;
using System.Linq;

namespace Logica
{
   public class ClienteService
    {
        ClienteRepository clienteRepository;
        public ConexionManeger Conection;

        public ClienteService(string conection)
        {
            Conection = new ConexionManeger(conection);
            clienteRepository = new ClienteRepository(Conection);
        }

        //CONEXION A BASE

        public string GuardarVehiculo_DB(Cliente cliente)
        {
            try
            {
                Conection.Open();
                clienteRepository.B_GuardarCliente(cliente);
                return "Cliente guardado correctamente";
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

        public class ConsultaReponse
        {
            public List<Cliente> Clientes { get; set; }
            public string Mensaje { get; set; }


            public bool Error { get; set; }
            public ConsultaReponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public ConsultaReponse(List<Cliente> clientes)
            {
                Clientes = clientes;
                Error = false;
            }
        }

        public ConsultaReponse ConsultarClientes_DB()
        {

            try
            {
                Conection.Open();
                return new ConsultaReponse(clienteRepository.B_ConsultarCliente().ToList());
            }
            catch (Exception e)
            {
                return new ConsultaReponse($"Error, {e.Message}");
            }
            finally
            {
                Conection.Close();
            }
        }

        public string B_ActualizarCliente(Cliente cliente)
        {
            try
            {
                Conection.Open();
                clienteRepository.B_ActualizarCliente(cliente);
                return "Cliente actualizado correctamnte";
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

        public string B_EliminarCliente(string cedula)
        {
            try
            {
                Conection.Open();
                clienteRepository.B_EliminarCliente(cedula);
                return "Cliente eliminado correctamnte";
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
