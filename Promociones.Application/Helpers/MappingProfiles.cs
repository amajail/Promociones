using AutoMapper;
using Promociones.Application.ViewModels;
using Promociones.Domain.Models;

namespace Promociones.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Promocion, PromocionViewModel>();
            CreateMap<PromocionViewModel, Promocion>();
        }
    }
}
