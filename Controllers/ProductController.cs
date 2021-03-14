using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Micro_Ejemplo.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> VerProds()
        {            
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> VerProd(string id)
        {
            return Products.Single(x => x.id == id);
        }

        [HttpPost]
        public ActionResult AggProd(Product model)
        {
            model.id = (Products.Count()).ToString(); //Se le asigna el id de manera automática al nuevo producto que se agregue

            Products.Add(model);

            return CreatedAtAction
            (
                "Get",
                new { a = model.id.ToString() },
                model 
            );
        }

        [HttpPut("{prodid}")]
        public ActionResult ModProd(string prodid, Product model)
        {
            var o = Products.Single(x => x.id == prodid);
            o.nombre = model.nombre;
            o.precio = model.precio;

            return NoContent();
        }

        [HttpDelete("{prodid}")]
        public ActionResult DelPord(string prodid, Product model)
        {
            Products = Products.Where(x => x.id != prodid).ToList();

            return NoContent();
        }

        private static List<Product> Products = new List<Product>
        {
            new Product
            {
                id = "0",
                nombre = "Monitor",
                precio = 100
            },

            new Product
            {
                id = "1",
                nombre = "Teclado",
                precio = 40
            },
        }; //Se crean los productos
    }
}
