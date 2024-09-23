using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.Supplier;

namespace NEBULOUS.Controllers.Routs.Get.Supplier
{
    [Route("api/[controller]")]
    [ApiController]
    public class Supplier : ControllerBase
    {
        // suppliers
        [HttpGet(Urls.Urls.Suppliers)]
        public IActionResult suppliers()
        {
            bool res = false;
            if (res)
            {
                res = true;
                return Ok(res);
            }
            else
            {
                return Ok("Ruta Suppliers");
            }
        }

        // Obtener todos los proveedores
        [HttpGet(Urls.Urls.Suppliers + "/methods/read/")]
        public async Task<ActionResult> readSuppliers([FromServices] string connection_sql)
        {
            var Suppliers = await Task.FromResult(new LSupplier(connection_sql).Suppliers());

            if (Suppliers == null)
            {
                return StatusCode(500, "Error al leer los usuario.");
            }

            return Ok(Suppliers);
        }

        // Obtener un solo proveedor
        [HttpGet(Urls.Urls.Suppliers + "/methods/read/one-register/")]
        public async Task<ActionResult> readOneUser([FromForm] int id, [FromServices] string connection_sql)
        {
            var supplier = await Task.FromResult(new LSupplier(connection_sql).ReadOneSupplier(id));

            if (supplier == null)
            {
                return StatusCode(500, "Error al leer los usuario.");
            }

            return Ok(supplier);
        }
    }
}
