namespace Promociones.Domain.Interfaces
{
    public interface IPromocionesDatabaseSettings
    {
        string PromocionesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
