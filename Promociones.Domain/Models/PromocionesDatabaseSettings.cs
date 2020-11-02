using Promociones.Domain.Interfaces;

namespace Promociones.Domain.Models
{
    public class PromocionesDatabaseSettings : IPromocionesDatabaseSettings
    {
        public string PromocionesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
