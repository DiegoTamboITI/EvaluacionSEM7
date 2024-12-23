using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController
    {
        private readonly DataContext _dataContext; 
        public UsuariosController(DataContext context)
        {
            _dataContext = context;
        }
        [HttpPost] 
        public async Task<IActionResult> AddUsuario([FromBody] Usuario usuarios)
        { 
            if (usuarios == null) 
            { 
                return BadRequest("El usuario no puede ser nulo."); 
            } 
            _dataContext.Add(usuarios); 
            await _dataContext.SaveChangesAsync(); 
            return Ok("Usuario agregado exitosamente."); 
        }
        // C-R-U-D

        /* [HttpGet("{id}")]
         public async Task<IActionResult> LeerUsuario(int id)
         {
             try
             {
                 var usuarios = await _dataContext.usuarios.FindAsync(id);
                 if (usuarios == null)
                 {
                     return NotFound("Coordinador no encontrado");
                 }

                 return Ok(usuarios);
             }
             catch (Exception ex) // sirve para que no termine abruptamente el programa
             {
                 return StatusCode(500, $"Error interno: {ex.Message}");
             }
         }

         [HttpPut("{id}")]
         public async Task<IActionResult> ActualizarUsuario(int id, Coordinador usuarioActualizado)
         {
             if (usuarioActualizado == null || id != usuarioActualizado.UsuarioId)
             {
                 return BadRequest("Datos inválidos para actualizar");
             }

             try
             {
                 var usuarioActualizado = await _dataContext.usuarios.FindAsync(id);
                 if (usuarioActualizado == null)
                 {
                     return NotFound("Coordinador no encontrado");
                 }
                 usuarioActualizado.Nombre = usuarioActualizado.Nombre;
                 usuarioActualizado.Apellido = usuarioActualizado.Apellido;
                 _dataContext.coordinadors.Update(usuariosExistente);
                 await _dataContext.SaveChangesAsync();

                 return Ok("Coordinador actualizado exitosamente");
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
                 if (usuario == null)
                 {
                     return NotFound("Usuario no encontrado");
                 }
                 _dataContext.coordinadors.Remove(usuario);
                 await _dataContext.SaveChangesAsync();
                 return Ok("Usuario eliminado exitosamente");
             }
             catch (Exception ex)
             {
                 return StatusCode(500, $"Error interno: {ex.Message}");
             }

         }*/
    }
}