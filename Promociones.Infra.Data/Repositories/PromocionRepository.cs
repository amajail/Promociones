using MongoDB.Driver;
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

        public Promocion GetPromocion(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Promocion> GetPromocion(string bodyText, DateTime updatedFrom, long headerSizeLimit)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAllPromociones()
        {
            throw new NotImplementedException();
        }

        public bool RemovePromocion(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePromocion(string id, string body)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePromocionDocument(string id, string body)
        {
            throw new NotImplementedException();
        }

    }
}
