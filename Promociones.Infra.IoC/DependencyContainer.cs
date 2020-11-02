using Microsoft.Extensions.DependencyInjection;
using Promociones.Application.Interfaces;
using Promociones.Application.Services;
using Promociones.Domain.Interfaces;
using Promociones.Infra.Data.Context;
using Promociones.Infra.Data.Repositories;

namespace Promociones.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Promocion.Application
            services.AddScoped<IPromocionService, PromocionService>();

            //Promocion.Domain.Interfaces | Promocion.Infra.Data.Repositories
            services.AddScoped<IPromocionRepository, PromocionRepository>();

            //Promociones.Infra.Data.Contex
            services.AddScoped<IPromocionesDbContext, PromocionesDbContext >();
        }
    }
}
