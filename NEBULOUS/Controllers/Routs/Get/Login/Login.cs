using Microsoft.AspNetCore.Mvc;

namespace NEBULOUS.Controllers.Routs.Get.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        // login
        [HttpGet(Urls.Urls.Login)]
        public IActionResult login()
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                return Ok("No es posible acceder a esta ruta debido a que has iniciado sesión.");
            }
            else
            {
                return Ok("Estás en la ruta login, no has iniciado sesión, por favor, inicia sesión para ingresar al sistema.");
            }
        }
    }
}
