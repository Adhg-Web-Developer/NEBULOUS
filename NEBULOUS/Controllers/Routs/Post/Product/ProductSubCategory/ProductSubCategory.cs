using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.Product.ProductSubCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Post.Product.ProductSubCategory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSubCategory : ControllerBase
    {
        // Product Sub-Category
        // Crear
        [HttpPost(Urls.Urls.ProductSubCategory + "/methods/create/")]
        public async Task<ActionResult> createProductCategory([FromForm, Bind(Prefix = "")] Models.Product.ProductSubCategory.ProductSubCategory productSubCategory, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                bool res = await Task.FromResult(new LProductSubCategory(connection_sql).CreateProductSubCategory(productSubCategory));

                if (productSubCategory == null && !res)
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
        [HttpPost(Urls.Urls.ProductSubCategory + "/methods/modify/")]
        public async Task<ActionResult> modifyProductCategory([FromForm, Bind(Prefix = "")] Models.Product.ProductSubCategory.ProductSubCategory productSubCategory, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProductSubCategory(connection_sql).ModifyProductSubCategory(productSubCategory));

                    if (productSubCategory == null && !res)
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
        [HttpPost(Urls.Urls.ProductSubCategory + "/methods/delete/")]
        public async Task<ActionResult> deleteProductCategory([FromForm] int id, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProductSubCategory(connection_sql).DeleteProductSubCategory(id));

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
