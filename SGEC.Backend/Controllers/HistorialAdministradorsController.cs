using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialAdministradorsController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public HistorialAdministradorsController(DataContext context)
        {
            _datacontext = context;
        }

        [HttpPost]

        public async Task<IActionResult> addHistorialAdministrador(HistorialAdministrador historialadministradores)
        {
            _datacontext.Add(historialadministradores);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("{id}")] 
        public async Task<IActionResult> LeerHistorialAdministrador(int id) 
        {
            try 
            { 
                var historialAdministrador = await _datacontext.historialadministradores.FindAsync(id);
                if (historialAdministrador == null) 
                { 
                    return NotFound("Historial de administrador no encontrado."); 
                }
                return Ok(historialAdministrador); 
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            } 
        }
       
               
        [HttpPut("{id}")] 
        public async Task<IActionResult> ActualizarHistorialAdministrador(int id, [FromBody] HistorialAdministrador historialAdministradorActualizado)
        {
            if (historialAdministradorActualizado == null || id != historialAdministradorActualizado.HistorialAdministradorId) 
            {
                return BadRequest("Datos inválidos para actualizar."); 
            }
            try 
            { 
                var historialAdministradorExistente = await _datacontext.historialadministradores.FindAsync(id); 
                if (historialAdministradorExistente == null) 
                {
                    return NotFound("Historial de administrador no encontrado."); 
                }
                historialAdministradorExistente.TecnicoId = historialAdministradorActualizado.TecnicoId; 
                historialAdministradorExistente.FechaInicio = historialAdministradorActualizado.FechaInicio;
                historialAdministradorExistente.FechaFin = historialAdministradorActualizado.FechaFin; 
                _datacontext.historialadministradores.Update(historialAdministradorExistente); 
                await _datacontext.SaveChangesAsync(); 
                return Ok("Historial de administrador actualizado exitosamente."); 
            } catch (Exception ex) 
            {
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarHistorialAdministrador(int id)
        {
            try
            {
                var historialAdministrador = await _datacontext.historialadministradores.FindAsync(id);
                if (historialAdministrador == null)
                {
                    return NotFound("Historial de administrador no encontrado.");
                }
                _datacontext.historialadministradores.Remove(historialAdministrador);
                await _datacontext.SaveChangesAsync();
                return Ok("Historial de administrador eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }


        }
}
