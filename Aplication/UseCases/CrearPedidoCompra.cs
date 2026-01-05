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
    public class CrearPedidoCompra
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrearPedidoCompra(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<ResumenPedidoDTOs> Execute(PedidoCompraDTOs dto)
        {
            // 1. Validar que el Comercio existe
            var comercio = await _unitOfWork.Comercio.GetByAsync(dto.IdComercio);

            // Usamos una validación simple. Si es nulo, lanzamos error.
            if (comercio == null)
            {
                throw new Exception($"El comercio con ID {dto.IdComercio} no existe.");
            }

            // === CORRECCIÓN AQUÍ: Validar también la ubicación ===
            if (comercio.UbicacionLocal == null)
            {
                throw new Exception($"El comercio {comercio.Nombre} no tiene una ubicación configurada.");
            }

            // 2. Convertir DTO a Entidad Pedido
            var pedido = _mapper.Map<Pedido>(dto);

            // 3. Completar datos que no vienen en el DTO
            pedido.TipoServicio = TipoServicio.Compra;
            pedido.Estado = EstadoPedido.Pendiente;
            pedido.FechaCreacion = DateTime.Now;

            // 4. Lógica de Ubicación: 
            // El origen del viaje es la ubicación del comercio.
            pedido.UbicacionOrigen = new Ubicacion
            {
                Latitud = comercio.UbicacionLocal.Latitud,
                Longitud = comercio.UbicacionLocal.Longitud,
                DireccionTexto = comercio.UbicacionLocal.DireccionTexto,
                Referencia = "Recoger en local: " + comercio.Nombre
            };

            // 5. Calcular Totales
            // Sumamos precio * cantidad de cada detalle
            if (pedido.Detalles != null && pedido.Detalles.Any())
            {
                pedido.TotalProductos = pedido.Detalles.Sum(d => d.PrecioUnitario * d.Cantidad);
            }

            // MOCK de Tarifa: Cobramos 5.00 base + algo por distancia simulada
            pedido.CostoEnvio = 10.00m;

            // 6. Guardar usando UnitOfWork
            await _unitOfWork.Pedido.AddAsync(pedido);
            await _unitOfWork.SaveAsync();

            // 7. Retornar respuesta
            return _mapper.Map<ResumenPedidoDTOs>(pedido);
        }
    }
}
