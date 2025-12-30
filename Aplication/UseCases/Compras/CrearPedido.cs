using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Compras
{
    public class CrearPedido
    {
        private readonly IPedido _pedido;
        private readonly IMapper _mapper;

        public CrearPedido(IPedido pedido, IMapper mapper)
        {
            _pedido = pedido;
            _mapper = mapper;
        }

        public async Task<Guid> Ejecutar(PedidoDTOs dto)
        {
            var pedido = _mapper.Map<Pedido>(dto);
            
            await _pedido.Guardar(pedido);

            return pedido.Id;
        }
    }
}
