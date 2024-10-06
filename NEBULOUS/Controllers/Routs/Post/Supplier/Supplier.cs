using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.Supplier;

namespace NEBULOUS.Controllers.Routs.Post.Supplier
{
    [Route("api/[controller]")]
    [ApiController]
    public class Supplier : ControllerBase
    {
        // Suppliers
        // Crear
        [HttpPost(Urls.Urls.Suppliers + "/methods/create/")]
        public async Task<ActionResult> createSupplier([FromForm, Bind(Prefix = "")] Models.Supplier.Supplier supplier, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                bool res = await Task.FromResult(new LSupplier(connection_sql).CreateSupplier(supplier));

                if (supplier == null && !res)
                {
                    return StatusCode(500, "Error al crear el proveedor.");
                }

                return Ok(res);
            }
            else
            {
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }

        // Modificar
        [HttpPost(Urls.Urls.Suppliers + "/methods/modify/")]
        public async Task<ActionResult> modifySupplier([FromForm, Bind(Prefix = "")] Models.Supplier.Supplier supplier, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LSupplier(connection_sql).ModifySupplier(supplier));

                    if (supplier == null && !res)
                    {
                        return StatusCode(500, "Error al crear el proveedor.");
                    }

                    return Ok(res);
                }
                else
                {
                    return Ok("No es posible realizar esta acción debido a que no cuentas con los permisos necesarios.");
                }
            }
            else
            {
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }

        // Eliminar
        [HttpPost(Urls.Urls.Suppliers + "/methods/delete/")]
        public async Task<ActionResult> deleteSupplier([FromForm] int id, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LSupplier(connection_sql).DeleteSupplier(id));

                    if (res == false && !res)
                    {
                        return StatusCode(500, "Error al crear el usuario.");
                    }

                    return Ok(res);
                }
                else
                {
                    return Ok("No es posible realizar esta acción debido a que no cuentas con los permisos necesarios.");
                }
            }
            else
            {
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }
    }
}
