using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.Product.ProductBrands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Post.Product.ProductBrands
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrands : ControllerBase
    {
        // Product Brands
        // Crear
        [HttpPost(Urls.Urls.ProductBrands + "/methods/create/")]
        public async Task<ActionResult> createProductBrands([FromForm, Bind(Prefix = "")] Models.Product.ProductBrands.ProductBrands productBrands, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                bool res = await Task.FromResult(new LProductBrands(connection_sql).CreateProductBrands(productBrands));

                if (productBrands == null && !res)
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
        public async Task<ActionResult> modifyProductBrands([FromForm, Bind(Prefix = "")] Models.Product.ProductBrands.ProductBrands productBrands, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProductBrands(connection_sql).ModifyProductBrands(productBrands));

                    if (productBrands == null && !res)
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
        public async Task<ActionResult> deleteProductBrands([FromForm] int id, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LProductBrands(connection_sql).DeleteProductBrands(id));

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
