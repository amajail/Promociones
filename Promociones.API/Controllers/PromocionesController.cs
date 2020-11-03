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
        public async Task<ActionResult<PromocionesViewModel>> Get()
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
        public async Task<ActionResult<PromocionesViewModel>> GetVigentes()
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
            var promociones = await _promocionService.GetVigentesAsync(venta);

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
            return Ok(p.Id);
        }

        //// Modificar una promoción
        //// PUT: api/Promociones/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Guid>> Put(Guid id, [FromBody] Promocion pr)
        //{
        //    var p = await _promocionService.GetByGuidAsync(id);
        //    if (p == null)
        //    {
        //        return NotFound();
        //    }

        //    await _promocionService.Update(id, pr);

        //    return Ok(pr.Id);
        //}

        //// Eliminar una promoción
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var p = await _promocionService.GetByGuidAsync(id);

        //    if (p == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
    }
}
