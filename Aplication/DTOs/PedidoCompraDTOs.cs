using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class PedidoCompraDTOs
    {
        public string NombreCliente { get; set; } = string.Empty;
        public string TelefonoCliente { get; set; } = string.Empty;

        // Datos del Comercio (A quién compramos)
        public int IdComercio { get; set; }

        // Dónde se entrega (El origen se saca del IdComercio en BD)
        public UbicacionDTOs? UbicacionEntrega { get; set; }

        // Lista de cosas que compra
        public List<DetalleProductoDTOs> Productos { get; set; } = new();

    }
}
