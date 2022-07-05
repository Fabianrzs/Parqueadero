using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        private string cedula;
        private string nombre;
        private string apellido;
        private string celular;
        private string genero;
        private string correo;
        private string direccion;
        private string ciudad;

        public Cliente(string cedula, string nombre, string apellido, string celular, string genero, string correo, string direccion, string ciudad)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.celular = celular;
            this.genero = genero;
            this.correo = correo;
            this.direccion = direccion;
            this.ciudad = ciudad;
        }
        public Cliente() { }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
    }
}
