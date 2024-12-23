using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputadorsController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public ComputadorsController(DataContext context)
        {
            _datacontext = context;
        }

        [HttpPost]
        public async Task<IActionResult> addComputador(Computador computadores)
        {
            _datacontext.Add(computadores);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")] public async Task<IActionResult> LeerComputador(int id) 
        { try 
            { var computadores = await _datacontext.computadores.FindAsync(id); 
                if (computadores == null) 
                { 
                    return NotFound("Computador no encontrado."); 
                } 
                return Ok(computadores); 
            } 
            catch (Exception ex) 
         { 
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarComputador(int id, [FromBody] Computador computadorActualizado)
        {
            if (computadorActualizado == null || id != computadorActualizado.ComputadorId) { return BadRequest("Datos inválidos para actualizar."); }
            try
            {
                var computadorExistente = await _datacontext.computadores.FindAsync(id); 
                if (computadorExistente == null) 
                { 
                    return NotFound("Computador no encontrado."); 
                }

                computadorExistente.Modelo = computadorActualizado.Modelo; 
                computadorExistente.Marca = computadorActualizado.Marca; 
                computadorExistente.NumeroSerie = computadorActualizado.NumeroSerie; 
                computadorExistente.CodigoBien = computadorActualizado.CodigoBien; 
                computadorExistente.Estado = computadorActualizado.Estado; 
                computadorExistente.OrdenCompraId = computadorActualizado.OrdenCompraId; 
                computadorExistente.ContratoId = computadorActualizado.ContratoId; 
                
                _datacontext.computadores.Update(computadorExistente); 
                await _datacontext.SaveChangesAsync(); 
                return Ok("Computador actualizado exitosamente.");
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            }

        }
        [HttpDelete("{id}")] 
        public async Task<IActionResult> EliminarComputador(int id) 
        { 
            try 
            { 
                var computador = await _datacontext.computadores.FindAsync(id); 
                if (computador == null) 
                {
                    return NotFound("Computador no encontrado."); 
                } 
                _datacontext.computadores.Remove(computador); 
                await _datacontext.SaveChangesAsync();
                return Ok("Computador eliminado exitosamente."); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            } 
        }




    }
}
