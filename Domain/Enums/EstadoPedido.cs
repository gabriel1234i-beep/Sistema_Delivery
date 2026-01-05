using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EstadoPedido
    {
        Pendiente = 1,
        Asignado = 2,
        EnCamino = 3,
        Entrergado = 4,
        Cancelado = 0
    }
}
