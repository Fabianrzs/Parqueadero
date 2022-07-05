using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EstacionamientoService
    {
        EstacionamientoRepository estacionamientoRepository;
        public ConexionManeger Conection;

        public EstacionamientoService(string conection)
        {
            Conection = new ConexionManeger(conection);
            estacionamientoRepository = new EstacionamientoRepository(Conection);
        }

        //CONEXION A BASE


        public string GuardarEstacionamiento_DB(Estacionamiento estacionamiento)
        {
            try
            {
                Conection.Open();
                estacionamientoRepository.B_GuardarEstacionamiento(estacionamiento);
                return "Estacionamiento guardado correctamnte";
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
            public List<Estacionamiento> Reservas { get; set; }
            public string Mensaje { get; set; }


            public bool Error { get; set; }
            public ConsultaReponse1(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public ConsultaReponse1(List<Estacionamiento> estacionamientos)
            {
                Reservas = estacionamientos;
                Error = false;
            }
        }

        public ConsultaReponse1 ConsultarEstacionamientos_DB()
        {

            try
            {
                Conection.Open();
                return new ConsultaReponse1(estacionamientoRepository.B_ConsultarEstacionamiento().ToList());
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

        public string B_ActualizarEstacionamiento(Estacionamiento estacionamiento)
        {
            try
            {
                Conection.Open();
                estacionamientoRepository.B_ActualizarEstacionamiento(estacionamiento);
                return "Estacionamiento actualizado correctamnte";
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

        public string B_EliminarEstacionamiento(string codigo)
        {
            try
            {
                Conection.Open();
                estacionamientoRepository.B_EliminarEstacionamiento(codigo);
                return "Estacionamiento eliminado correctamnte";
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
