using Aplication.DTOs;
using Aplication.UseCases;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // Inyectamos los Casos de Uso para ESCRITURA (POST)
        private readonly CrearPedidoCompra _crearCompraUseCase;
        private readonly CrearPedidoEnvio _crearEnvioUseCase;

        // Inyectamos UnitOfWork para LECTURA (GET) - Consultas rápidas
        private readonly IUnitOfWork _unitOfWork;

        public PedidoController(
            CrearPedidoCompra crearCompraUseCase,
            CrearPedidoEnvio crearEnvioUseCase,
            IUnitOfWork unitOfWork)
        {
            _crearCompraUseCase = crearCompraUseCase;
            _crearEnvioUseCase = crearEnvioUseCase;
            _unitOfWork = unitOfWork;
        }

        // POST api/pedido/compra
        [HttpPost("compra")]
        public async Task<IActionResult> CrearCompra([FromBody] PedidoCompraDTOs dto)
        {
            try
            {
                var resultado = await _crearCompraUseCase.Execute(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // POST api/pedido/envio
        [HttpPost("envio")]
        public async Task<IActionResult> CrearEnvio([FromBody] PedidoEnvioDTOs dto)
        {
            try
            {
                var resultado = await _crearEnvioUseCase.Execute(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET api/pedido/pendientes
        // Para ver qué pedidos se han creado
        [HttpGet("pendientes")]
        public async Task<IActionResult> ObtenerPendientes()
        {
            var pedidos = await _unitOfWork.Pedido.GetPedidosPendientesAsync();
            return Ok(pedidos);
        }
    }
}
