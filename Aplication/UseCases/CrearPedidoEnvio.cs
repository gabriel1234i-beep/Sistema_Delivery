using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class CrearPedidoEnvio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrearPedidoEnvio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResumenPedidoDTOs> Execute(PedidoEnvioDTOs dto)
        {
            // 1. Convertir DTO a Entidad
            // AutoMapper se encarga de UbicacionOrigen y UbicacionDestino gracias al MappingProfile
            var pedido = _mapper.Map<Pedido>(dto);

            // 2. Configurar el tipo de servicio
            pedido.TipoServicio = TipoServicio.EnvioPaquete;
            pedido.Estado = EstadoPedido.Pendiente;
            pedido.FechaCreacion = DateTime.Now;

            // En envío de paquetes no hay costo de productos (comida), es cero.
            pedido.TotalProductos = 0;
            pedido.IdComercio = null; // No hay comercio asociado

            // 3. Calcular Tarifa de Envío (Lógica Mock)
            // Aquí calcularíamos distancia entre pedido.UbicacionOrigen y pedido.UbicacionDestino
            // Simulamos una tarifa un poco más cara por ser servicio de mensajería
            pedido.CostoEnvio = 15.00m;

            // 4. Guardar
            await _unitOfWork.Pedido.AddAsync(pedido);
            await _unitOfWork.SaveAsync();

            // 5. Retornar
            return _mapper.Map<ResumenPedidoDTOs>(pedido);
        }
    }
}
