using Microsoft.AspNetCore.Mvc;
using SGEC.Backend.Data;
using SGEC.Shared.Entities;

namespace SGEC.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenComprasController : ControllerBase
    {
       private readonly DataContext _datacontext;
        public OrdenComprasController(DataContext context)
        {
            _datacontext = context;
        }

        [HttpPost]
        public async Task <IActionResult> addOrdenCompra(OrdenCompra ordencompras)
        {
            _datacontext.Add(ordencompras);
            await _datacontext.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("{id}")] 
        public async Task<IActionResult> LeerOrdenCompra(int id)
        {
            try 
            { 
                var ordenCompra = await _datacontext.ordencompras.FindAsync(id); 
                if (ordenCompra == null) 
                {
                    return NotFound("Orden de compra no encontrada.");
                }
                return Ok(ordenCompra); 
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        
        
        [HttpPut("{id}")] 
        public async Task<IActionResult> ActualizarOrdenCompra(int id, [FromBody] OrdenCompra ordenCompraActualizada) 
        {
            if (ordenCompraActualizada == null || id != ordenCompraActualizada.OrdenCompraId) 
            {
                return BadRequest("Datos inválidos para actualizar.");
            }
            try 
            {
                var ordenCompraExistente = await _datacontext.ordencompras.FindAsync(id);
                if (ordenCompraExistente == null)
                {
                    return NotFound("Orden de compra no encontrada.");
                }
                ordenCompraExistente.NumeroCompra = ordenCompraActualizada.NumeroCompra; 
                ordenCompraExistente.FechaOrden = ordenCompraActualizada.FechaOrden; 
                ordenCompraExistente.Proveedor = ordenCompraActualizada.Proveedor; 
                ordenCompraExistente.MontoTotal = ordenCompraActualizada.MontoTotal; 
                _datacontext.ordencompras.Update(ordenCompraExistente);
                await _datacontext.SaveChangesAsync(); 
                return Ok("Orden de compra actualizada exitosamente."); 
            } catch (Exception ex) { return StatusCode(500, $"Error interno: {ex.Message}"); 
            }
        }
        
        [HttpDelete("{id}")] 
        public async Task<IActionResult> EliminarOrdenCompra(int id) 
        {
            try 
            {
                var ordenCompra = await _datacontext.ordencompras.FindAsync(id); 
                if (ordenCompra == null) 
                {
                    return NotFound("Orden de compra no encontrada.");
                }
                _datacontext.ordencompras.Remove(ordenCompra); 
                await _datacontext.SaveChangesAsync(); 
                return Ok("Orden de compra eliminada exitosamente."); 
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error interno: {ex.Message}"); 
            }
        }


    }
}
