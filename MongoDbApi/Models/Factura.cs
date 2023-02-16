using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbApi.Models
{
    public class Factura
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string? CodigoFactura { get; set; }

        public string? Cliente { get; set; }

        public string? Ciudad { get; set; }

        public float Nit { get; set; }

        public float Subtotal { get; set; }
        public float TotalFactura { get; set; }

        

        public float Iva { get; set; }

        public int Retencion { get; set; }

        public DateTime? DateTimeDateTime { get; set; }

        public string? Estado { get; set; }

        public Boolean Pagada { get; set; }
        
        public DateTime? FechaPago { get; set; }


    }
}
