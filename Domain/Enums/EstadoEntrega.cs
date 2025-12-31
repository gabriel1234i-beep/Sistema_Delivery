using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EstadoEntrega
    {
        Creado = 1,
        Asignado = 2,
        EnCamino = 3,
        Entregado = 4,
        Fallido = 0
    }
}
