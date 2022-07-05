using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteRepository
    {
        
        
        public ConexionManeger conexion;
        public SqlDataReader reader;
        static List<Cliente> clientes = new List<Cliente>();
      

        public ClienteRepository(ConexionManeger conexion)
        {
            this.conexion = conexion;
            clientes = new List<Cliente>();
            
        }


        //CONEXION A BASE

        public void B_ActualizarCliente(Cliente cliente)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "ModificarCliente";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cliente.Cedula;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.Nombre;
                command.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.Apellido;
                command.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.Celular;
                command.Parameters.Add("@genero", SqlDbType.VarChar).Value = cliente.Genero;
                command.Parameters.Add("@correo", SqlDbType.VarChar).Value = cliente.Correo;
                command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                command.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = cliente.Ciudad;
                command.ExecuteNonQuery();
            }
        }

        public void B_EliminarCliente(string cedula)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "EliminarCliente";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cedula;
                command.ExecuteNonQuery();
            }
        }

        public void B_GuardarCliente(Cliente cliente)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "GuardarCliente";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cliente.Cedula;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.Nombre;
                command.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.Apellido;
                command.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.Celular;
                command.Parameters.Add("@genero", SqlDbType.VarChar).Value = cliente.Genero;
                command.Parameters.Add("@correo", SqlDbType.VarChar).Value = cliente.Correo;
                command.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                command.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = cliente.Ciudad;
                command.ExecuteNonQuery();
            }
        }

        public IList<Cliente> B_ConsultarCliente()
        {
            clientes.Clear();
            using (var comand = conexion.Connection.CreateCommand())
            {
                comand.CommandText = "select * from cliente";
                reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente;
                    cliente = MapearCliente_BD(reader);
                    clientes.Add(cliente);

                }
            }
            return clientes;
        }

       public Cliente MapearCliente_BD(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();
            cliente.Cedula = (string)reader["cedula"];
            cliente.Nombre = (string)reader["nombre"];
            cliente.Apellido = (string)reader["apellido"];
            cliente.Celular = (string)reader["celular"];
            cliente.Genero = (string)reader["genero"];
            cliente.Correo = (string)reader["correo"];
            cliente.Direccion = (string)reader["direccion"];
            cliente.Ciudad = (string)reader["ciudad"];

            return cliente;
        }
     }
    }

