using Aplication.DTOs;
using Aplication.DTOs.Envio;
using AutoMapper;
using Domain.Entities;
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
        private readonly IMapper _mapper;

        public CrearEntrega(IEntrega entrega, IMapper mapper)
        {
            _entrega = entrega;
            _mapper = mapper;
        }

        public async Task<Guid> Ejecutar(EntregaDTOs dto)
        {
            var envio = _mapper.Map<Entrega>(dto);

            await _entrega.Guardar(envio);

            return envio.Id;
        }
    }
}
