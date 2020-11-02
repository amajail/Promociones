using Microsoft.AspNetCore.Mvc;
using Promociones.Application.Interfaces;
using Promociones.Application.ViewModels;
using System.Collections.Generic;

namespace Promociones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {

        private IPromocionService _promocionService;

        public PromocionesController(IPromocionService promocionService)
        {
            _promocionService = promocionService;
        }


        // GET: api/Promociones
        [HttpGet]
        public PromocionViewModel Get()
        {
            return _promocionService.GetPromociones();
        }

        // GET: api/Promociones/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Promociones
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Promociones/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
