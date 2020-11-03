using System.Collections.Generic;

namespace Promociones.Application.ViewModels
{
    public class VentaViewModel
    {
        public string MedioDePago { get; set; }
        public string Banco { get; set; }
        public IEnumerable<string> CategoriaProducto { get; set; }
    }
}
