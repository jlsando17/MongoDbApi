using MongoDbApi.Models;



namespace MongoDbApi.Repositories
{
    public interface IFacturaCollection
    {
        Task InsertFactura(Models.Factura factura);

        Task UpdateFactura(Models.Factura factura);

        Task DeleteFactura(string id);

        Task<List<Models.Factura>> GetAllFactura();

        Task<Factura>GetFacturaById(string id);
    }
}
//Task para que todo el proceso sea asincrono