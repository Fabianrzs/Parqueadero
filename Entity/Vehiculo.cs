using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Vehiculo
    {
        private string placa;
        private string propietario;
        private string cedula;
        private string modelo;
        private string tipoVehiculo;
        private string horaEntrada;
        private string horaSalida;
        private string descripcion;

        public Vehiculo(string placa, string propietario, string cedula, string modelo, string tipoVehiculo, string horaEntrada, string horaSalida, string descripcion)
        {
            this.placa = placa;
            this.propietario = propietario;
            this.cedula = cedula;
            this.modelo = modelo;
            this.tipoVehiculo = tipoVehiculo;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
            this.descripcion = descripcion;
        }

        public Vehiculo(){}

        public string Placa { get => placa; set => placa = value; }
        public string Propietario { get => propietario; set => propietario = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string TipoVehiculo { get => tipoVehiculo; set => tipoVehiculo = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
