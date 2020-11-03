using AutoMapper;
using Promociones.Application.Interfaces;
using Promociones.Application.ViewModels;
using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;
using Promociones.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.Application.Services
{
    public class PromocionService : IPromocionService
    {
        public IPromocionRepository _promocionRepository;
        private readonly IMapper _mapper;

        public PromocionService(IPromocionRepository promocionRepository, IMapper mapper)
        {
            _promocionRepository = promocionRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(PromocionViewModel p)
        {
            var promo = await _promocionRepository.Create(_mapper.Map<PromocionViewModel,Promocion>(p));
            return promo.Id;
        }
        public async Task<PromocionViewModel> GetByGuidAsync(Guid guid)
        {
            var promocion = await _promocionRepository.GetByGuidAsync(guid);

            return promocion != null ? _mapper.Map<Promocion, PromocionViewModel>(promocion) : null;
        }

        public async Task<PromocionesViewModel> GetPromocionesAsync()
        {
            var promociones = await _promocionRepository.GetPromociones(new PromocionesSpecification());

            return promociones.Count > 0 ? MapearAListaViewModel(promociones) : null;
        }

        public async Task<PromocionesViewModel> GetVigentesAsync(DateTime fecha)
        {
            var promociones = await _promocionRepository.GetPromociones(new PromocionesFechaSpecification(fecha));

            return promociones.Count > 0 ? MapearAListaViewModel(promociones) : null;
        }

        public async Task<PromocionesViewModel> GetVigentesAsync(VentaViewModel venta)
        {
            var promociones = await _promocionRepository.GetPromociones(new PromocionesVentaSpecification(venta.MedioDePago, venta.Banco, venta.CategoriaProducto));

            return promociones.Count > 0 ? MapearAListaViewModel(promociones) : null;
        }

        public Task<Guid> Update(Guid id, PromocionViewModel pr)
        {
            throw new NotImplementedException();
        }

        private PromocionesViewModel MapearAListaViewModel(IReadOnlyList<Promocion> promociones)
        {
            return new PromocionesViewModel { Promociones = promociones.Select(p => _mapper.Map<Promocion, PromocionViewModel>(p)) };
        }
    }
}
