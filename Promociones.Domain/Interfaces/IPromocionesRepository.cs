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
        Task<Promocion> Create(Promocion p);
        Task<bool> UpdatePromocion(Guid id, Promocion body);
        Task<bool> Remove(Guid id);
    }
}
