using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;
namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratosController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public ContratosController(DataContext context)
        {
            _datacontext = context;
        }

        [HttpPost]
        public async Task<IActionResult> addContrato(Contrato contratos)
        {
            _datacontext.Add(contratos);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("{id}")] 
        public async Task<IActionResult> LeerContrato(int id) 
        { 
            try 
            { 
                var contrato = await _datacontext.contratos.FindAsync(id); 
                if (contrato == null) 
                { 
                    return NotFound("Contrato no encontrado."); 
                }
                
                return Ok(contrato); 
            } 
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            } 
        }
       
                
        [HttpPut("{id}")] 
        public async Task<IActionResult> ActualizarContrato(int id, [FromBody] Contrato contratoActualizado) 
        {
            if (contratoActualizado == null || id != contratoActualizado.ContratoId) 
            {
                return BadRequest("Datos inválidos para actualizar.");
            } 
            try 
            { 
                var contratoExistente = await _datacontext.contratos.FindAsync(id); 
                if (contratoExistente == null) 
                { 
                    return NotFound("Contrato no encontrado."); 
                }
                contratoExistente.NumeroContrato = contratoActualizado.NumeroContrato; 
                contratoExistente.FechaContrato = contratoActualizado.FechaContrato; 
                contratoExistente.Proveedor = contratoActualizado.Proveedor;
                contratoExistente.MontoTotal = contratoActualizado.MontoTotal;
                
                _datacontext.contratos.Update(contratoExistente); 
                await _datacontext.SaveChangesAsync();
                return Ok("Contrato actualizado exitosamente."); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, $"Error interno: {ex.Message}");
            } 
        }
        
              
        [HttpDelete("{id}")] 
        public async Task<IActionResult> EliminarContrato(int id) 
        { 
            try 
            { 
                var contrato = await _datacontext.contratos.FindAsync(id);
                if (contrato == null) 
                {
                    return NotFound("Contrato no encontrado."); 
                }
                
                _datacontext.contratos.Remove(contrato); 
                await _datacontext.SaveChangesAsync(); 
                return Ok("Contrato eliminado exitosamente."); 
            } 
            catch (Exception ex) { return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }




    }
}
