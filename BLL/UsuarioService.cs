using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UsuarioService
    {
        UsuarioRepository usuarioRepository;
        public ConexionManeger Conection;

        public UsuarioService(string conection)
        {
            Conection = new ConexionManeger(conection);
            usuarioRepository = new UsuarioRepository(Conection);
        }

        //CONEXION A BASE DE DATOS

        public string GuardarUsuario_DB(Usuario usuario)
        {
            try
            {
                Conection.Open();
                usuarioRepository.B_GuardarUsuario(usuario);
                return "Usuario guardado correctamnte";
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
            public List<Usuario> Usuarios { get; set; }
            public string Mensaje { get; set; }


            public bool Error { get; set; }
            public ConsultaReponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public ConsultaReponse(List<Usuario> usuarios)
            {
                Usuarios = usuarios;
                Error = false;
            }
        }

        public ConsultaReponse ConsultarUsuarios_DB()
        {

            try
            {
                Conection.Open();
                return new ConsultaReponse(usuarioRepository.B_ConsultarUsuario().ToList());
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

        public string B_ActualizarUsuario(Usuario usuario)
        {
            try
            {
                Conection.Open();
                usuarioRepository.B_ActualizarUsuario(usuario);
                return "Usuario actualizado correctamnte";
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

        public string B_EliminarUsuario(string contraseña)
        {
            try
            {
                Conection.Open();
                usuarioRepository.B_EliminarUsuario(contraseña);
                return "Usuario eliminado correctamnte";
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
