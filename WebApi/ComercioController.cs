using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComercioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST api/comercio
        // Usamos la entidad directa para hacerlo rápido (en producción usaríamos un DTO)
        [HttpPost]
        public async Task<IActionResult> CrearComercio([FromBody] ComercioRef comercio)
        {
            await _unitOfWork.Comercio.AddAsync(comercio);
            await _unitOfWork.SaveAsync();
            return Ok(new { mensaje = "Comercio creado", id = comercio.Id });
        }

        [HttpGet]
        public async Task<IActionResult> ListarComercios()
        {
            var lista = await _unitOfWork.Comercio.GetAllAsync();
            return Ok(lista);
        }
    }
}
