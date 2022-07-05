using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Usuario
    {
        private string Nombreusuario;
        private string contraseña;
        private string confirmacion;

        public Usuario(string nombreusuario, string contraseña, string confirmacion)
        {
            Nombreusuario = nombreusuario;
            this.contraseña = contraseña;
            this.confirmacion = confirmacion;
        }

        public Usuario(){}

        public string NombreUsuario { get => Nombreusuario; set => Nombreusuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Confirmacion { get => confirmacion; set => confirmacion = value; }
    }
}
