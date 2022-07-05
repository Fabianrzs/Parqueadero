using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Ticket
    {
        private string id;
        private string fecha;
        private string horaEntrada;
        private string horaSalida;
        private string Cedula;
        private string placa;
        private string nombre;
        private string tipoVehiculo;

        public Ticket(string id, string fecha, string horaEntrada, string horaSalida, string cedula, string placa, string nombre, string tipoVehiculo)
        {
            this.id = id;
            this.fecha = fecha;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
            Cedula = cedula;
            this.placa = placa;
            this.nombre = nombre;
            this.tipoVehiculo = tipoVehiculo;
        }

        public Ticket(){}

        public string Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string Cedula1 { get => Cedula; set => Cedula = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string TipoVehiculo { get => tipoVehiculo; set => tipoVehiculo = value; }
    }
}
