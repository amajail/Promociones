using Promociones.Domain.Models;
using System.Collections.Generic;

namespace Promociones.Application.ViewModels
{
    public class PromocionViewModel
    {
        public IEnumerable<Promocion> Promociones { get; set; }
    }
}
