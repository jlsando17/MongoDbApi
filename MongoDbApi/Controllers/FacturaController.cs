using Microsoft.AspNetCore.Mvc;
using MongoDbApi.Models;
using MongoDbApi.Repositories;

namespace MongoDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private IFacturaCollection db=new FacturaCollection();
        
        [HttpGet]
        public async Task<IActionResult>GetAllFacturas()
        {
            return Ok(await db.GetAllFactura());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacturasDetails(string id)
        {
            return Ok(await db.GetFacturaById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFactura([FromBody] Factura factura)
        {
            if (factura == null)
                return BadRequest();

            if (factura.Cliente == string.Empty) 
            {
                ModelState.AddModelError("Cliente", "El cliente no deberia estar vacio");
            }
            await db.InsertFactura(factura);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFactura([FromBody] Factura factura,string id)
        {
            if (factura == null)
                return BadRequest();

            if (factura.Cliente == string.Empty)
            {
                ModelState.AddModelError("Cliente", "El cliente no deberia estar vacio");
            }
            factura.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateFactura(factura);

            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(string id)
        {
            await db.DeleteFactura(id);
            return NoContent(); //Todo salio correctamente
        }
    }
}
