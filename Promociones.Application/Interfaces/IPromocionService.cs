using Promociones.Application.ViewModels;
using Promociones.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promociones.Application.Interfaces
{
    public interface IPromocionService
    {
        Task<PromocionesViewModel> GetPromocionesAsync();
        Task<PromocionViewModel> GetByGuidAsync(Guid guid);
        Task<PromocionesViewModel> GetVigentesAsync(DateTime fecha);
        Task<PromocionesViewModel> GetVigentesAsync(VentaViewModel venta);
        Task<Guid> Create(PromocionViewModel p);
        Task<Guid> Update(Guid id, PromocionViewModel pr);

    }
}
