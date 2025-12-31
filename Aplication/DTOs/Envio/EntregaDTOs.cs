using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs.Envio
{
    public class EntregaDTOs
    {
        public string Descripcion {  get; set; } = string.Empty;
        public DireccionDTOs Recojo { get; set; } = new DireccionDTOs();
        public DireccionDTOs Entrega { get; set; } = new DireccionDTOs();
        public string PersonaContacto { get; set; } = string.Empty;
        public string TelefonoContacto { get; set; } = string.Empty;

    }
}
