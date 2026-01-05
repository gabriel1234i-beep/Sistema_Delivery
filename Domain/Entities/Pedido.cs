using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public string NombreCliente { get; set; } = string.Empty;
        public string TelefonoCliente { get; set; } = string.Empty;

        //Tipo de servicio (compra o envio)

        public TipoServicio TipoServicio {  get; set; }
        public EstadoPedido Estado { get; set; }

        // Logica de direcciones

        public Ubicacion? UbicacionOrigen {  get; set; }
        public Ubicacion? UbicacionDestino { get; set; }

        //Datos de Pagos
        public decimal CostoEnvio { get; set; }
        public decimal TotalProductos { get; set; }
        public decimal Total => CostoEnvio + TotalProductos;

        //Relaciones
        //repartidor
        public int? IdRepartidor { get; set; }
        public RepartidorRef? Repartidor { get; set; }

        //comercio
        public int? IdComercio { get; set; }
        public ComercioRef? Comercio {  get; set; }
        //descripcion del paquete si es envio
        public string DescripcionPaquete { get; set; } = string.Empty;
        //Detalles (Solo si es compra)
        public ICollection<DetallePedido>? Detalles { get; set; }
    }
}
