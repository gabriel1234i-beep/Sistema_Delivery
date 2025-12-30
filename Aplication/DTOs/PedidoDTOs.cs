using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs;
public record PedidoDTOs
(
    Guid IdCliente,
    Guid IdComercio,
    List<ItemDTO> Items,
    DireccionDTO DireccionEntrega
);

public record ItemDTO(string Producto, int Cantidad, decimal Precio);
public record DireccionDTO(string Calle,string Ciudad, string Referencia, double Latitud, double Longitud);
