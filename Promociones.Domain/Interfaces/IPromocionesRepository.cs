using Promociones.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promociones.Domain.Interfaces
{
    public interface IPromocionRepository
    {
        Task<Promocion> GetByGuidAsync(Guid guid);
        Task<IReadOnlyList<Promocion>> GetPromociones(ISpecification<Promocion> specification);
        // query after multiple parameters
        IEnumerable<Promocion> GetPromocion(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        // add new Promocion document
        Task<Promocion> Create(Promocion p);

        // remove a single document / Promocion
        bool RemovePromocion(string id);

        // update just a single document / Promocion
        bool UpdatePromocion(string id, string body);

        // demo interface - full document update
        bool UpdatePromocionDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        bool RemoveAllPromociones();

    }
}
