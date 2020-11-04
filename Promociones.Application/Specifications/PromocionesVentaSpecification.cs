using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Promociones.Domain.Specifications
{
    public class PromocionesVentaSpecification : ISpecification<Promocion>
    {
        private readonly string _medioDePago;
        private readonly string _banco;
        private readonly IEnumerable<string> _categoriaProducto;

        public PromocionesVentaSpecification(string medioDePago, string banco, IEnumerable<string> categoriaProducto)
        {
            _medioDePago = medioDePago;
            _banco = banco;
            _categoriaProducto = categoriaProducto;
        }

        public Expression<Func<Promocion, bool>> Criteria()
        {
            return p =>
            (_medioDePago == null || p.MediosDePago.Contains(_medioDePago)) &&
            (_banco == null || p.Bancos.Contains(_banco)) &&
            (_categoriaProducto.Count() == 0 || p.CategoriasProductos.Where(i => _categoriaProducto.Contains(i)).Count() > 0)
            ;
        }
    }
}
