
using MongoDB.Driver;
using MongoDbApi.Models;
using MongoDB.Bson;

namespace MongoDbApi.Repositories
{
    public class FacturaCollection : IFacturaCollection
    {
        internal MongoDbRepository _repository=new MongoDbRepository();
        private IMongoCollection<Factura> Collection;

        public FacturaCollection()
        {
            Collection = _repository.db.GetCollection<Factura>("Facturas");
        }

        async Task IFacturaCollection.DeleteFactura(string id)
        {

            var filter = Builders<Factura>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        async Task<List<Factura>> IFacturaCollection.GetAllFactura()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        async Task<Factura> IFacturaCollection.GetFacturaById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id",new ObjectId(id)} }).Result.FirstAsync();
        }

        async Task IFacturaCollection.InsertFactura(Factura factura)
        {
            await Collection.InsertOneAsync(factura);
        }

        async Task IFacturaCollection.UpdateFactura(Factura factura)
        {
            var filter = Builders<Factura>
                .Filter
                .Eq(s => s.Id, factura.Id);
            await Collection.ReplaceOneAsync(filter, factura);
        }
    }
}
