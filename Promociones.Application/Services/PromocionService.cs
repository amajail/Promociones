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
            var promo = await _promocionRepository.Create(_mapper.Map<PromocionViewModel, Promocion>(p));

            
            return promo.Id;
        }
        public async Task<PromocionViewModel> GetByGuidAsync(Guid guid)
        {
            var promocion = await _promocionRepository.GetByGuidAsync(guid);

            return promocion != null ? _mapper.Map<Promocion, PromocionViewModel>(promocion) : null;
        }

        public async Task<IEnumerable<PromocionViewModel>> GetPromocionesAsync()
        {
            var promociones = await _promocionRepository.GetPromociones(new PromocionesSpecification());

            return promociones.Select(p => _mapper.Map<Promocion, PromocionViewModel>(p));
        }

        public async Task<IEnumerable<PromocionViewModel>> GetVigentesAsync(DateTime fecha)
        {
            var promociones = await _promocionRepository.GetPromociones(new PromocionesFechaSpecification(fecha));

            return promociones.Select(p => _mapper.Map<Promocion, PromocionViewModel>(p));
        }

        public async Task<IEnumerable<PromocionVentaViewModel>> GetVigentesVentaAsync(VentaViewModel venta)
        {
            var promociones = await _promocionRepository.GetPromociones(new PromocionesFechaSpecification(DateTime.Today));

            promociones.Where(new PromocionesVentaSpecification(venta.MedioDePago, venta.Banco, venta.CategoriaProducto).Criteria().Compile());

            return promociones.Select(p => _mapper.Map<Promocion, PromocionVentaViewModel>(p));
        }

        public async Task<bool> Update(Guid id, PromocionViewModel p)
        {
            var promo = _mapper.Map<PromocionViewModel, Promocion>(p);

            return await _promocionRepository.UpdatePromocion(id, promo); ;
        }

        public async Task<bool> Remove(Guid id)
        {
            return await _promocionRepository.Remove(id);
        }
    }
}
