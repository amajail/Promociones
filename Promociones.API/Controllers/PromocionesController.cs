using Microsoft.AspNetCore.Mvc;
using Promociones.Application.Interfaces;
using Promociones.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promociones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {

        private readonly IPromocionService _promocionService;

        public PromocionesController(IPromocionService promocionService)
        {
            _promocionService = promocionService;
        }

        // Ver listado de promociones
        // GET: api/Promociones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromocionViewModel>>> Get()
        {
            var promociones = await _promocionService.GetPromocionesAsync();

            return Ok(promociones);
        }

        // Ver una promoción - Parámetros de entrada: Id: Guid
        // GET: api/Promociones/5
        [HttpGet("guid/{guid}")]
        public async Task<ActionResult<PromocionViewModel>> GetByGuid(Guid guid)
        {
            var promocion = await _promocionService.GetByGuidAsync(guid);

            if (promocion == null)
            {
                return NotFound();
            }

            return Ok(promocion);
        }

        // Ver listado de promociones vigentes
        // GET: api/Promociones/5
        [HttpGet("vigentes")]
        public async Task<ActionResult<IEnumerable<PromocionViewModel>>> GetVigentes()
        {
            var promociones = await _promocionService.GetVigentesAsync(DateTime.Today);

            if (promociones == null)
            {
                return NotFound();
            }

            return Ok(promociones);
        }

        // Ver listado de promociones vigentes para una fecha x  - Parámetros de entrada: fecha
        [HttpGet("vigentes/{fecha}")]
        public async Task<ActionResult<PromocionViewModel>> GetVigentesFecha(DateTime fecha)
        {
            var promociones = await _promocionService.GetVigentesAsync(fecha);

            if (promociones == null)
            {
                return NotFound();
            }

            return Ok(promociones);
        }

        // Ver listado de promociones vigentes para una venta
        [HttpPost("vigentes")]
        public async Task<ActionResult<PromocionViewModel>> GetVigentesVenta(VentaViewModel venta)
        {
            var promociones = await _promocionService.GetVigentesVentaAsync(venta);

            if (promociones == null)
            {
                return NotFound();
            }

            return Ok(promociones);
        }

        // Crear una promoción
        // POST: api/Promociones
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] PromocionViewModel p)
        {
            if (ModelState.IsValid)
            {
                await _promocionService.Create(p);
            }
            else
            {
                return BadRequest();
            }
            return Ok(p.Id);
        }

        // Modificar una promoción
        // PUT: api/Promociones/5
        [HttpPut("{guid}")]
        public async Task<ActionResult<Guid>> Put(Guid guid, [FromBody] PromocionViewModel pr)
        {
            var p = await _promocionService.GetByGuidAsync(guid);

            if (p == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _promocionService.Update(guid, pr);
            }
            else
            {
                return BadRequest();
            }

            return Ok(pr.Id);
        }

        // Eliminar una promoción
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete(Guid guid)
        {
            var p = await _promocionService.GetByGuidAsync(guid);

            if (p == null)
            {
                return NotFound();
            }

            await _promocionService.Remove(guid);

            return NoContent();
        }
    }
}
