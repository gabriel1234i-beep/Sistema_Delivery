using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepartidorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRepartidor([FromBody] RepartidorRef repartidor)
        {
            await _unitOfWork.Repartidor.AddAsync(repartidor);
            await _unitOfWork.SaveAsync();
            return Ok(new { mensaje = "Repartidor registrado", id = repartidor.Id });
        }

        [HttpGet("disponibles")]
        public async Task<IActionResult> ListarDisponibles()
        {
            var lista = await _unitOfWork.Repartidor.GetRepartidorDisponibleAsync();
            return Ok(lista);
        }
    }
}
