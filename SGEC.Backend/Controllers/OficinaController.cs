using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OficinaController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public OficinaController(DataContext context)
        {
            _datacontext = context;
        }

        [HttpPost]
        public async Task<IActionResult> addOficina(Oficina oficinas)
        {
            _datacontext.Add(oficinas);
            await _datacontext.SaveChangesAsync();
            return Ok(oficinas);
        }


        [HttpGet("{id}")] 
        public async Task<IActionResult> LeerOficina(int id) 
        {
            try 
            {
                var oficina = await _datacontext.oficinas.FindAsync(id); 
                if (oficina == null) 
                { 
                    return NotFound("Oficina no encontrada."); 
                } 
                return Ok(oficina); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Error interno: {ex.Message}");
            } 
        }
        
        
        
        [HttpPut("{id}")] 
        public async Task<IActionResult> ActualizarOficina(int id, [FromBody] Oficina oficinaActualizada)
        { 
            if (oficinaActualizada == null || id != oficinaActualizada.OficinaId)
            {
                return BadRequest("Datos inválidos para actualizar.");
            } 
            try 
            { 
                var oficinaExistente = await _datacontext.oficinas.FindAsync(id); 
                if (oficinaExistente == null) 
                { 
                    return NotFound("Oficina no encontrada."); 
                } 
                oficinaExistente.NombreOficina = oficinaActualizada.NombreOficina;
                oficinaExistente.Ubicacion = oficinaActualizada.Ubicacion; 
                _datacontext.oficinas.Update(oficinaExistente);
                await _datacontext.SaveChangesAsync(); 
                return Ok("Oficina actualizada exitosamente."); 
            } 
            catch (Exception ex) { return StatusCode(500, $"Error interno: {ex.Message}");
            } 
        }
                
        [HttpDelete("{id}")] 
        public async Task<IActionResult> EliminarOficina(int id) 
        { 
            try
            { 
                var oficina = await _datacontext.oficinas.FindAsync(id); 
                if (oficina == null)
                {
                    return NotFound("Oficina no encontrada."); 
                }
                _datacontext.oficinas.Remove(oficina);
                await _datacontext.SaveChangesAsync();
                return Ok("Oficina eliminada exitosamente."); 
            } 
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }


    }
}
