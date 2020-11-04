using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;
using Promociones.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.Infra.Data.Repositories
{
    public class PromocionRepository : IPromocionRepository
    {
        public IPromocionesDbContext _context;
        public PromocionRepository(IPromocionesDbContext context)
        {
            _context = context;
        }

        public async Task<Promocion> Create(Promocion p)
        {
            try
            {
                p.Activar();
                p.CargarFechaCreate();

                await _context.Promociones.InsertOneAsync(p);
                return p;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Promocion> GetByGuidAsync(Guid guid)
        {
            return await _context
                .Promociones
                .Find(promocion => promocion.Id == guid)
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Promocion>> GetPromociones(ISpecification<Promocion> specification)
        {
            return await _context
                .Promociones
                .Find(specification.Criteria())
                .ToListAsync();
        }

        public async Task<bool> UpdatePromocion(Guid id, Promocion p)
        {
            var filter = Builders<Promocion>.Filter.Eq(nameof(p.Id), id);

            var update = Builders<Promocion>.Update
                .Set(nameof(p.Bancos), p.Bancos)
                .Set(nameof(p.CategoriasProductos), p.CategoriasProductos)
                .Set(nameof(p.FechaFin), p.FechaFin)
                .Set(nameof(p.FechaInicio), p.FechaInicio)
                .Set(nameof(p.FechaModificacion), DateTime.Today)
                .Set(nameof(p.MaximaCantidadDeCuotas), p.MaximaCantidadDeCuotas)
                .Set(nameof(p.MediosDePago), p.MediosDePago)
                .Set(nameof(p.PorcentajeDeDescuento), p.PorcentajeDeDescuento)
                .Set(nameof(p.ValorInteresCuotas), p.ValorInteresCuotas);

            var replaceOneResult = await _context.Promociones.UpdateOneAsync(filter, update);

            return replaceOneResult.IsAcknowledged;
        }

        public async Task<bool> Remove(Guid id)
        {
            var filter = Builders<Promocion>.Filter.Eq("Id", id);
            var update = Builders<Promocion>.Update
                .Set("Activo", false)
                .Set("FechaModificacion", DateTime.Today);

            var result = await _context.Promociones.UpdateOneAsync(filter, update);

            return result.IsAcknowledged;
        }
    }
}
