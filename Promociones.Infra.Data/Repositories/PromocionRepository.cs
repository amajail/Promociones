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

        public async Task<IReadOnlyList<Promocion>> GetAllPromocionesAsync()
        {
            try
            {
                return await _context
                    .Promociones
                    .Find(promocion => true).ToListAsync();
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

        public async Task<IReadOnlyList<Promocion>> GetPromocionesVigentesAsync(DateTime fecha)
        {
            //las fechas podrian estar en nulo
            return await _context
                .Promociones
                .Find(promocion => (!promocion.FechaInicio.HasValue || promocion.FechaInicio.Value <= fecha) && (!promocion.FechaInicio.HasValue || promocion.FechaFin.Value >= fecha))
                .ToListAsync();
        }


        public async Task<IReadOnlyList<Promocion>> GetPromocionesVigentesAsync(string medioDePago, string banco, IEnumerable<string> categoriaProducto)
        {
            return await _context
                .Promociones
                .Find(promocion => promocion.MediosDePago.Count() == 0 || promocion.MediosDePago.Contains(medioDePago))
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
