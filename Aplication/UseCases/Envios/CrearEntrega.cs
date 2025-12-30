using Aplication.DTOs;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Envios
{
    public class CrearEntrega
    {
        private readonly IEntrega _entrega;
        public CrearEntrega(IEntrega entrega)
        {
            _entrega = entrega;
        }

        public async Task<Guid> Ejecutar(EntregaDTOs dto)
        {
            var puntoRecojo = new Direccion(dto.;
        }
    }
}
