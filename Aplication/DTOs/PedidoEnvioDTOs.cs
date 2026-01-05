using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class PedidoEnvioDTOs
    {
        public string NombreCliente { get; set; } = string.Empty;
        public string TelefonoCliente { get; set; } = string.Empty;

        public string DescripcionPaquete { get; set; } = string.Empty;

        public UbicacionDTOs? UbicacionRecojo { get; set; }
        public UbicacionDTOs? UbicacionEntrega { get; set; }
    }
}
