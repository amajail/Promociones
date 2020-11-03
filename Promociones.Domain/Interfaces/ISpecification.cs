using System;
using System.Linq.Expressions;

namespace Promociones.Domain.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria();
    }
}
