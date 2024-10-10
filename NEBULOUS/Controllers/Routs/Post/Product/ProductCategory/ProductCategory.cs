using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.Product.ProductCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Post.Product.ProductCategory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategory : ControllerBase
    {
        // Product Category
        // Crear
        [HttpPost(Urls.Urls.ProductCategory + "/methods/create/")]
        public async Task<ActionResult> createProductCategory([FromForm, Bind(Prefix = "")] Models.Product.ProductCategory.ProductCategory productCategory, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                bool res = await Task.FromResult(new LProductCategory(connection_sql).CreateProductCategory(productCategory));

                if (productCategory == null && !res)
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
        [HttpPost(Urls.Urls.ProductCategory + "/methods/modify/")]
        public async Task<ActionResult> modifyProductCategory([FromForm, Bind(Prefix = "")] Models.Product.ProductCategory.ProductCategory productCategory, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProductCategory(connection_sql).ModifyProductCategory(productCategory));

                    if (productCategory == null && !res)
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
        [HttpPost(Urls.Urls.ProductCategory + "/methods/delete/")]
        public async Task<ActionResult> deleteProductCategory([FromForm] int id, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProductCategory(connection_sql).DeleteProductCategory(id));

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
