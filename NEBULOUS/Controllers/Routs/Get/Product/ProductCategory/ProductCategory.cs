using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Get.Product.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategory : ControllerBase
    {
        // ProductCategory
        [HttpGet(Urls.Urls.ProductCategory)]
        public IActionResult productCategory()
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                return Ok("Estás en la ruta Categoría de Productos.");
            }
            else
            {
                return Ok("No es posible acceder a esta ruta debido a que no has iniciado sesión.");
            }
        }
    }
}
