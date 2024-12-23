using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;
using System.Threading.Tasks;
namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActaEntregasController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public ActaEntregasController(DataContext context)
        {
            _datacontext = context;
        }

        // crud

        [HttpPost]

        public async Task<IActionResult> AddActaEntrega([FromBody] ActaEntrega actaentregas) 
        { if (actaentregas == null) 
            { 
                return BadRequest("El acta de entrega no puede ser nula.");
            } 
            _datacontext.Add(actaentregas); await _datacontext.SaveChangesAsync(); 
            return Ok("Acta de entrega agregada exitosamente."); 
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> LeerActaEntrega(int id)
        {
            try
            {
                var actaentregas = await _datacontext.actasentregas.FindAsync(id);
                if (actaentregas == null)
                {
                    return NotFound("Acta Entrega no encontrada");
                }

                return Ok(actaentregas);
            }
            catch (Exception ex) // sirve para que no termine abruptamente el programa
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarActaEntrega(int id, ActaEntrega actaentregaActualizado)
        {
            if (actaentregaActualizado == null || id != actaentregaActualizado.ActaEntregaId)
            {
                return BadRequest("Datos inválidos para actualizar");
            }

            try
            {
                var actaEntregaExistente = await _datacontext.actasentregas.FindAsync(id);
                if (actaEntregaExistente == null)
                {
                    return NotFound("Coordinador no encontrado");
                }

                actaEntregaExistente.ComputadorId = actaentregaActualizado.ComputadorId;
                actaEntregaExistente.UsuarioId = actaentregaActualizado.UsuarioId; 
                actaEntregaExistente.OficinaId = actaentregaActualizado.OficinaId;
                actaEntregaExistente.FechaEntrega = actaentregaActualizado.FechaEntrega; 
                actaEntregaExistente.TecnicoId = actaentregaActualizado.TecnicoId;

                _datacontext.actasentregas.Update(actaEntregaExistente);
                await _datacontext.SaveChangesAsync();
                return Ok("Acta de entrega actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarActaEntrega(int id)
        {
            try
            {
                var actaentregas = await _datacontext.actasentregas.FindAsync(id);
                if (actaentregas == null)
                {
                    return NotFound("Acta Entrega no encontrado");
                }
                _datacontext.actasentregas.Remove(actaentregas);
                await _datacontext.SaveChangesAsync();
                return Ok("Acta Entrega eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }



    }
}
