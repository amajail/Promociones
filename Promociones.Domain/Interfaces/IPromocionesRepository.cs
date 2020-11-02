using Promociones.Domain.Models;
using System;
using System.Collections.Generic;

namespace Promociones.Domain.Interfaces
{
    public interface IPromocionRepository
    {
        IEnumerable<Promocion> GetAllPromociones();
        Promocion GetPromocion(string id);

        // query after multiple parameters
        IEnumerable<Promocion> GetPromocion(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        // add new Promocion document
        bool AddPromocion(Promocion item);

        // remove a single document / Promocion
        bool RemovePromocion(string id);

        // update just a single document / Promocion
        bool UpdatePromocion(string id, string body);

        // demo interface - full document update
       bool UpdatePromocionDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        bool RemoveAllPromociones();
    }
}
