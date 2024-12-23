using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TecnicosController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public TecnicosController(DataContext context)
        {
            _datacontext = context;
        }
        [HttpPost]
        public async Task<IActionResult> addTecnico(Tecnico tecnicos)
        {
            _datacontext.Add(tecnicos);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }

        
        [HttpGet("{id}")] 
        public async Task<IActionResult> LeerTecnico(int id) 
        {
            try 
            {
                var tecnico = await _datacontext.tecnicos.FindAsync(id); 
                if (tecnico == null)
                {
                    return NotFound("Técnico no encontrado."); 
                } 
                return Ok(tecnico); 
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            } 
        }
        
        
        [HttpPut("{id}")] 
        public async Task<IActionResult> ActualizarTecnico(int id, [FromBody] Tecnico tecnicoActualizado) 
        { 
            if (tecnicoActualizado == null || id != tecnicoActualizado.TecnicoId) 
            { 
                return BadRequest("Datos inválidos para actualizar."); 
            } 
            try 
            { 
                var tecnicoExistente = await _datacontext.tecnicos.FindAsync(id); 
                if (tecnicoExistente == null) 
                {
                    return NotFound("Técnico no encontrado."); 
                } 
                tecnicoExistente.Nombre = tecnicoActualizado.Nombre; 
                tecnicoExistente.Apellido = tecnicoActualizado.Apellido; 
                tecnicoExistente.EsAdministrador = tecnicoActualizado.EsAdministrador; 
                _datacontext.tecnicos.Update(tecnicoExistente); 
                await _datacontext.SaveChangesAsync();
                return Ok("Técnico actualizado exitosamente.");
            } 
            catch (Exception ex)
            { 
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTecnico(int id) 
        { 
            try 
            { 
                var tecnico = await _datacontext.tecnicos.FindAsync(id); 
                if (tecnico == null) 
                { 
                    return NotFound("Técnico no encontrado."); 
                } 
                _datacontext.tecnicos.Remove(tecnico);
                await _datacontext.SaveChangesAsync();
                return Ok("Técnico eliminado exitosamente."); 
            } 
            catch (Exception ex)
            { 
                return StatusCode(500, $"Error interno: {ex.Message}");
            } 
        }



    }
}
