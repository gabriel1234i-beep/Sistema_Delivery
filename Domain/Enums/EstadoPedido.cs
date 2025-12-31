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
        Confirmado = 2,
        EnPreparacion = 3,
        ListoParaRecoger = 4,
        Entregado = 5,
        Cancelado = 0
    }
}
