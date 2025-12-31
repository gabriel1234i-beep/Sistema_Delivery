using Aplication.DTOs.Compra;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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
        private readonly IExternoService _externoService;

        public CrearPedido(IPedido pedido, IMapper mapper, IExternoService externoService)
        {
            _pedido = pedido;
            _mapper = mapper;
            _externoService = externoService;
        }

        public async Task<Guid> Ejecutar(PedidoDTOs pedidoDto)
        {
            var comercio = await _externoService.ObternerComercioPorId(pedidoDto.IdComercio);
            if (comercio == null)
            {
                throw new Exception("Comercio no encontrado");
            }
            var pedido = _mapper.Map<Pedido>(pedidoDto);

            await _pedido.Guardar(pedido);

            return pedido.Id;
        }
    }
}
