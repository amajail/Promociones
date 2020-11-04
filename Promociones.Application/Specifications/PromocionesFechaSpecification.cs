using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Promociones.Domain.Specifications
{
    public class PromocionesFechaSpecification : ISpecification<Promocion>
    {
        private readonly DateTime _fecha;

        public PromocionesFechaSpecification(DateTime fecha)
        {
            _fecha = fecha;
        }

        public Expression<Func<Promocion, bool>> Criteria()
        {
            return p => (p.Activo == true) &
                    (!p.FechaInicio.HasValue || p.FechaInicio.Value <= _fecha) &&
                    (!p.FechaInicio.HasValue || p.FechaFin.Value >= _fecha);
        }
    }
}
