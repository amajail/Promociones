using MongoDB.Driver;
using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;
using Promociones.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace Promociones.Infra.Data.Repositories
{
    public class PromocionRepository : IPromocionRepository
    {
        public IPromocionesDbContext _context;
        public PromocionRepository(IPromocionesDbContext context)
        {
            _context = context;
        }

        public bool AddPromocion(Promocion item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Promocion> GetAllPromociones() => 
            _context.Promociones.Find(promocion => true).ToList();

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
