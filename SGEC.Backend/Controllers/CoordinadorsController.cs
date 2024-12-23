using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoordinadorsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CoordinadorsController(DataContext context)
        {
            _dataContext = context;  
        }
        [HttpPost]
        public async Task<IActionResult> AddCoordinador([FromBody] Coordinador coordinadors)
        {
            if (coordinadors == null)
            {
                return BadRequest("El coordinador no puede ser nulo.");
            }
            _dataContext.Add(coordinadors);
            await _dataContext.SaveChangesAsync();
            return Ok("Coordinador agregado exitosamente.");
        }

        // C-R-U-D

        [HttpGet("{id}")]
        public async Task<IActionResult> LeerCoordinador(int id)
        {
            try
            {
                var coordinadors = await _dataContext.coordinadors.FindAsync(id);
                if (coordinadors == null)
                {
                    return NotFound("Coordinador no encontrado");
                }

                return Ok(coordinadors);
            }
            catch (Exception ex) // sirve para que no termine abruptamente el programa
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCoordinador(int id, Coordinador coordinadorActualizado)
        {
            if (coordinadorActualizado == null || id != coordinadorActualizado.CoordinadorId)
            {
                return BadRequest("Datos inválidos para actualizar");
            }

            try
            {
                var coordinadorExistente = await _dataContext.coordinadors.FindAsync(id);
                if (coordinadorExistente == null)
                {
                    return NotFound("Coordinador no encontrado");
                }
                coordinadorExistente.Nombre = coordinadorActualizado.Nombre;
                coordinadorExistente.Apellido = coordinadorActualizado.Apellido;
                _dataContext.coordinadors.Update(coordinadorExistente);
                await _dataContext.SaveChangesAsync();

                return Ok("Coordinador actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCoordinador(int id)
        {
            try
            {
                var coordinador = await _dataContext.coordinadors.FindAsync(id);
                if (coordinador == null)
                {
                    return NotFound("Coordinador no encontrado");
                }
                _dataContext.coordinadors.Remove(coordinador);
                await _dataContext.SaveChangesAsync();
                return Ok("Coordinador eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
