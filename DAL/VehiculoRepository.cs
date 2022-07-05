using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidad;
using System.Threading.Tasks;
using System.Data;

namespace Datos
{
    public class VehiculoRepository
    {
      

        public ConexionManeger conexion;
        public SqlDataReader reader;
        static List<Vehiculo> vehiculos = new List<Vehiculo>();

        public VehiculoRepository(ConexionManeger conexion)
        {
            this.conexion = conexion;
            vehiculos = new List<Vehiculo>();
        }

        //CONEXION A BASE

        public void B_ActualizarVehiculo(Vehiculo vehiculo)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "ModificarVehiculo";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@placa", SqlDbType.VarChar).Value = vehiculo.Placa;
                command.Parameters.Add("@propietario", SqlDbType.VarChar).Value = vehiculo.Propietario;
                command.Parameters.Add("@cedula", SqlDbType.VarChar).Value = vehiculo.Cedula;
                command.Parameters.Add("@modelo", SqlDbType.VarChar).Value = vehiculo.Modelo;
                command.Parameters.Add("@tipoVehiculo", SqlDbType.VarChar).Value = vehiculo.TipoVehiculo;
                command.Parameters.Add("@horaEntrada", SqlDbType.VarChar).Value = vehiculo.HoraEntrada;
                command.Parameters.Add("@horaSalida", SqlDbType.VarChar).Value = vehiculo.HoraSalida;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = vehiculo.Descripcion;
                command.ExecuteNonQuery();
            }
        }

        public void B_EliminarVehiculo(string placa)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "EliminarVehiculo";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@placa", SqlDbType.VarChar).Value = placa;
                command.ExecuteNonQuery();
            }
        }

        public void B_GuardarVehiculo(Vehiculo vehiculo) 
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "GuardarVehiculo";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@placa", SqlDbType.VarChar).Value = vehiculo.Placa;
                command.Parameters.Add("@propietario", SqlDbType.VarChar).Value = vehiculo.Propietario;
                command.Parameters.Add("@cedula", SqlDbType.VarChar).Value = vehiculo.Cedula;
                command.Parameters.Add("@modelo", SqlDbType.VarChar).Value = vehiculo.Modelo;
                command.Parameters.Add("@tipoVehiculo", SqlDbType.VarChar).Value = vehiculo.TipoVehiculo;
                command.Parameters.Add("@horaEntrada", SqlDbType.VarChar).Value = vehiculo.HoraEntrada;
                command.Parameters.Add("@horaSalida", SqlDbType.VarChar).Value = vehiculo.HoraSalida;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = vehiculo.Descripcion;
                command.ExecuteNonQuery();
            }
        }

        public IList<Vehiculo> B_ConsultarVehiculo()
        {
            vehiculos.Clear();
            using (var comand = conexion.Connection.CreateCommand())
            {
                comand.CommandText = "select * from vehiculo";
                reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Vehiculo vehiculo;
                    vehiculo = MapearBD(reader);
                    vehiculos.Add(vehiculo);
                }
            }
            return vehiculos;
        }

        public Vehiculo MapearBD(SqlDataReader reader)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.Placa = (string)reader["placa"];
            vehiculo.Propietario = (string)reader["propietario"];
            vehiculo.Cedula = (string)reader["cedula"];
            vehiculo.Descripcion = (string)reader["descripcion"];
            vehiculo.Modelo = (string)reader["modelo"];
            vehiculo.HoraEntrada = (string)reader["horaentrada"];
            vehiculo.HoraSalida= (string)reader["horasalida"];
            vehiculo.TipoVehiculo = (string)reader["tipovehiculo"];
            return vehiculo;
        }

     


        
    }
}
