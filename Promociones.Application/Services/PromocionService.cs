using Promociones.Application.Interfaces;
using Promociones.Application.ViewModels;
using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.Application.Services
{
    public class PromocionService : IPromocionService
    {
        public IPromocionRepository _promocionRepository;
        public PromocionService(IPromocionRepository promocionRepository)
        {
            _promocionRepository = promocionRepository;
        }

        public async Task<Guid> Create(PromocionViewModel p)
        {
            var promo = await _promocionRepository.Create(MapearPromocion(p));

            return promo.Id;
        }

        public async Task<PromocionViewModel> GetByGuidAsync(Guid guid)
        {
            var promocion = await _promocionRepository.GetByGuidAsync(guid);

            return promocion != null ? MapearAViewModel(promocion) : null;
        }

        public async Task<PromocionesViewModel> GetPromocionesAsync()
        {
            return MapearAListaViewModel(await _promocionRepository.GetAllPromocionesAsync());
        }

        public async Task<PromocionesViewModel> GetVigentesAsync(DateTime fecha)
        {
            var promociones = await _promocionRepository.GetPromocionesVigentesAsync(fecha);
            return promociones.Count > 0 ? MapearAListaViewModel(promociones) : null;
        }

        public async Task<PromocionesViewModel> GetVigentesAsync(VentaViewModel venta)
        {
            var promociones = await _promocionRepository.GetPromocionesVigentesAsync(venta.MedioDePago, venta.Banco, venta.CategoriaProducto);

            return promociones.Count > 0 ? MapearAListaViewModel(promociones) : null;
        }

        public Task<Guid> Update(Guid id, PromocionViewModel pr)
        {
            throw new NotImplementedException();
        }

        private PromocionesViewModel MapearAListaViewModel(IReadOnlyList<Promocion> promociones)
        {
            return new PromocionesViewModel { Promociones = (from p in promociones select MapearAViewModel(p)) };
        }

        private PromocionViewModel MapearAViewModel(Promocion p)
        {
            return new PromocionViewModel
            {
                Id = p.Id,
                MediosDePago = p.MediosDePago,
                Bancos = p.Bancos,
                CategoriasProductos = p.CategoriasProductos,
                MaximaCantidadDeCuotas = p.MaximaCantidadDeCuotas,
                ValorInteresCuotas = p.ValorInteresCuotas,
                PorcentajeDeDescuento = p.PorcentajeDeDescuento,
                FechaInicio = p.FechaInicio,
                FechaFin = p.FechaFin
            };
        }

        private Promocion MapearPromocion(PromocionViewModel p)
        {
            return new Promocion(p.Id, p.MediosDePago, p.Bancos, p.CategoriasProductos, p.MaximaCantidadDeCuotas, p.ValorInteresCuotas, p.PorcentajeDeDescuento, p.FechaInicio, p.FechaFin);
        }

    }
}
