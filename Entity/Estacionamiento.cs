using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Estacionamiento
    {
        private string codigo;
        private string capacidad;
        private string tipoEstacionamiento;

        public Estacionamiento(string codigo, string capacidad, string tipoEstacionamiento)
        {
            this.codigo = codigo;
            this.capacidad = capacidad;
            this.tipoEstacionamiento = tipoEstacionamiento;
        }

        public Estacionamiento() { }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Capacidad { get => capacidad; set => capacidad = value; }
        public string TipoEstacionamiento { get => tipoEstacionamiento; set => tipoEstacionamiento = value; }
    }
}
