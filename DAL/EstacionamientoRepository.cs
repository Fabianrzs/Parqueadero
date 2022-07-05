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
    public class EstacionamientoRepository
    {
        public ConexionManeger conexion;
        public SqlDataReader reader;
        static List<Estacionamiento> estacionamientos = new List<Estacionamiento>();

        public EstacionamientoRepository(ConexionManeger conexion)
        {
            this.conexion = conexion;
            estacionamientos = new List<Estacionamiento>();

        }

        //CONEXION A BASE

        public void B_ActualizarEstacionamiento(Estacionamiento estacionamiento)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "ModificarEstacionamiento";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@codigo", SqlDbType.VarChar).Value = estacionamiento.Codigo;
                command.Parameters.Add("@capacidad", SqlDbType.VarChar).Value = estacionamiento.Capacidad;
                command.Parameters.Add("@tipoEstacionamiento", SqlDbType.VarChar).Value = estacionamiento.TipoEstacionamiento;
                command.ExecuteNonQuery();
            }
        }

        public void B_EliminarEstacionamiento(string codigo)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "EliminarEstacionamiento";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;
                command.ExecuteNonQuery();
            }
        }

        public void B_GuardarEstacionamiento(Estacionamiento estacionamiento)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "GuardarEstacionamiento";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@codigo", SqlDbType.VarChar).Value = estacionamiento.Codigo;
                command.Parameters.Add("@capacidad", SqlDbType.VarChar).Value = estacionamiento.Capacidad;
                command.Parameters.Add("@tipoEstacionamiento", SqlDbType.VarChar).Value = estacionamiento.TipoEstacionamiento;
                command.ExecuteNonQuery();
            }
        }

        public IList<Estacionamiento> B_ConsultarEstacionamiento()
        {
            estacionamientos.Clear();
            using (var comand = conexion.Connection.CreateCommand())
            {
                comand.CommandText = "select * from estacionamiento";
                reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Estacionamiento estacionamiento;
                    estacionamiento = MapearEstacionamientoBD(reader);
                    estacionamientos.Add(estacionamiento);
                }
            }
            return estacionamientos;
        }

        public Estacionamiento MapearEstacionamientoBD(SqlDataReader reader)
        {
            Estacionamiento estacionamiento = new Estacionamiento();
            estacionamiento.Codigo = (string)reader["codigo"];
            estacionamiento.Capacidad = (string)reader["capacidad"];
            estacionamiento.TipoEstacionamiento = (string)reader["tipoEstacionamiento"];
            return estacionamiento;
        }
    }
}
