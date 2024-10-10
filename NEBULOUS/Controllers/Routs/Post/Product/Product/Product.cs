using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Post.Product.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        // Product
        // Crear
        [HttpPost(Urls.Urls.Products + "/methods/create/")]
        public async Task<ActionResult> createProduct([FromForm, Bind(Prefix = "")] Models.Product.Product.Product product, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                bool res = await Task.FromResult(new LProduct(connection_sql).CreateProduct(product));

                if (product == null && !res)
                {
                    return StatusCode(500, "Error al crear el registro.");
                }

                return Ok(res);
            }
            else
            {
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }

        // Modificar
        [HttpPost(Urls.Urls.Products + "/methods/modify/")]
        public async Task<ActionResult> modifyProduct([FromForm, Bind(Prefix = "")] Models.Product.Product.Product product, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProduct(connection_sql).ModifyProduct(product));

                    if (product == null && !res)
                    {
                        return StatusCode(500, "Error al modificar el registro.");
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
        [HttpPost(Urls.Urls.Products + "/methods/delete/")]
        public async Task<ActionResult> deleteProduct([FromForm] int id, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProduct(connection_sql).DeleteProduct(id));

                    if (res == false && !res)
                    {
                        return StatusCode(500, "Error al eliminar el registro.");
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
