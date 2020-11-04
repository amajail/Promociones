using AutoMapper;
using Promociones.Application.ViewModels;
using Promociones.Domain.Models;

namespace Promociones.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Promocion, PromocionViewModel>();
            CreateMap<Promocion, PromocionVentaViewModel>();
            CreateMap<PromocionViewModel, Promocion>();
        }
    }
}
