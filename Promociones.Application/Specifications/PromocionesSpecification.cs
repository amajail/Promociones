using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Promociones.Domain.Specifications
{
    public class PromocionesSpecification : ISpecification<Promocion>
    {
        public Expression<Func<Promocion, bool>> Criteria()
        {
            return p => true;
        }
    }
}
