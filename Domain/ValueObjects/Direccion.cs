using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record Direccion
    (
        string Calle,
        string Ciudad,
        string Referencia,
        double Latitud,
        double Longitud
     );
}
