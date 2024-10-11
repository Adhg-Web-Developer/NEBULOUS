using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Get.Product.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrands : ControllerBase
    {
        // ProductBrands
        [HttpGet(Urls.Urls.ProductBrands)]
        public IActionResult productBrands()
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                return Ok("Estás en la ruta Marca de Productos.");
            }
            else
            {
                return Ok("No es posible acceder a esta ruta debido a que no has iniciado sesión.");
            }
        }
    }
}
