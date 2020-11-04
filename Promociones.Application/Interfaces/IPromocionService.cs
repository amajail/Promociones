using Promociones.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promociones.Application.Interfaces
{
    public interface IPromocionService
    {
        Task<IEnumerable<PromocionViewModel>> GetPromocionesAsync();
        Task<PromocionViewModel> GetByGuidAsync(Guid guid);
        Task<IEnumerable<PromocionViewModel>> GetVigentesAsync(DateTime fecha);
        Task<IEnumerable<PromocionVentaViewModel>> GetVigentesVentaAsync(VentaViewModel venta);
        Task<Guid> Create(PromocionViewModel p);
        Task<bool> Update(Guid id, PromocionViewModel pr);
        Task<bool> Remove(Guid id);

    }
}
