using Promociones.Application.Interfaces;
using Promociones.Application.ViewModels;
using Promociones.Domain.Interfaces;

namespace Promociones.Application.Services
{
    public class PromocionService : IPromocionService
    {
        public IPromocionRepository _promocionRepository;
        public PromocionService(IPromocionRepository promocionRepository)
        {
            _promocionRepository = promocionRepository;
        }

        public PromocionViewModel GetPromociones()
        {
            return new PromocionViewModel()
            {
                Promociones = _promocionRepository.GetAllPromociones()
            };
        }
    }
}
