using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class UsuarioRepository
    {

        public ConexionManeger conexion;
        public SqlDataReader reader;
        static List<Usuario> usuarios = new List<Usuario>();

        public UsuarioRepository(ConexionManeger conexion)
        {
            this.conexion = conexion;
            usuarios = new List<Usuario>();
        }




        public void B_ActualizarUsuario(Usuario usuario)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "ModificarUsuario";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = usuario.Contraseña;
                command.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                command.Parameters.Add("@confirmacion  ", SqlDbType.VarChar).Value = usuario.Confirmacion;
                command.ExecuteNonQuery();
            }
        }

        public void B_EliminarUsuario(string contraseña)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "EliminarUsuario";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = contraseña;
                command.ExecuteNonQuery();
            }
        }

        public void B_GuardarUsuario(Usuario usuario)
        {
            using (var command = conexion.Connection.CreateCommand())
            {
                command.CommandText = "GuardarUsuario";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = usuario.Contraseña;
                command.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                command.Parameters.Add("@confirmacion", SqlDbType.VarChar).Value = usuario.Confirmacion;
                command.ExecuteNonQuery();
            }
        }

        public IList<Usuario> B_ConsultarUsuario()
        {
            usuarios.Clear();
            using (var comand = conexion.Connection.CreateCommand())
            {
                comand.CommandText = "select * from usuario";
                reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario;
                    usuario = MapearUsuarioBD(reader);
                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }

        public Usuario MapearUsuarioBD(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.Contraseña = (string)reader["contraseña"];
            usuario.NombreUsuario = (string)reader["nombreUsuario"];
            usuario.Confirmacion = (string)reader["confirmacion"];
            
            return usuario;
        }








    }
}
