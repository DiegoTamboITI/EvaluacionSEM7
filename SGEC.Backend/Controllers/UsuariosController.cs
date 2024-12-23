using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsuariosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost] public async Task<IActionResult> AddUsuario([FromBody] Usuario usuario)
        { 
            if (usuario == null)
            {
                return BadRequest("El usuario no puede ser nulo."); 
            }
            _dataContext.Add(usuario); 
            await _dataContext.SaveChangesAsync(); 
            return Ok("Usuario agregado exitosamente."); 
        }
       
        
        [HttpGet("{id}")] 
        public async Task<IActionResult> LeerUsuario(int id)
        { 
            try 
            { 
                var usuario = await _dataContext.usuarios.FindAsync(id); 
                if (usuario == null) 
                { 
                    return NotFound("Usuario no encontrado."); 
                }
                return Ok(usuario); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Error interno: {ex.Message}");
            } 
        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] Usuario usuarioActualizado) 
        {
            if (usuarioActualizado == null || id != usuarioActualizado.UsuarioId)
            { 
                return BadRequest("Datos inválidos para actualizar."); 
            }
            try
            { 
                var usuarioExistente = await _dataContext.usuarios.FindAsync(id); 
                if (usuarioExistente == null) 
                { 
                    return NotFound("Usuario no encontrado.");
                } 
                usuarioExistente.Nombre = usuarioActualizado.Nombre; 
                usuarioExistente.Apellido = usuarioActualizado.Apellido; 
                usuarioExistente.OficinaId = usuarioActualizado.OficinaId; 
                usuarioExistente.FechaAsignacion = usuarioActualizado.FechaAsignacion;
                _dataContext.usuarios.Update(usuarioExistente); 
                await _dataContext.SaveChangesAsync(); 
                return Ok("Usuario actualizado exitosamente."); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Error interno: {ex.Message}");
            } 
        }
        
        
        [HttpDelete("{id}")] 
        public async Task<IActionResult> EliminarUsuario(int id) 
        { 
            try
            { 
                var usuario = await _dataContext.usuarios.FindAsync(id); 
                if (usuario == null) { return NotFound("Usuario no encontrado.");
                }
                _dataContext.usuarios.Remove(usuario); 
                await _dataContext.SaveChangesAsync();
                return Ok("Usuario eliminado exitosamente.");
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }



    }
}