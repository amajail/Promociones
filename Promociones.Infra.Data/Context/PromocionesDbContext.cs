using MongoDB.Driver;
using Promociones.Domain.Interfaces;
using Promociones.Domain.Models;

namespace Promociones.Infra.Data.Context
{
    public class PromocionesDbContext : IPromocionesDbContext
    {
        private readonly IMongoDatabase _database;

        public PromocionesDbContext(IPromocionesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Promocion> Promociones => _database.GetCollection<Promocion>("Promociones");
    }

    public interface IPromocionesDbContext
    {
        IMongoCollection<Promocion> Promociones { get; }
    }
}
