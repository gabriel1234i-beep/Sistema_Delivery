using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class ResumenPedidoDTOs
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string TipoServicio { get; set; } = string.Empty;

        public decimal CostoEnvio { get; set; }
        public decimal Total { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
