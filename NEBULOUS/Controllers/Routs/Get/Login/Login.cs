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
            bool res = false;
            if (res)
            {
                res = true;
                return Ok(res);
            }
            else
            {
                //return Ok(res);
                return Ok("Ruta Login");
            }
        }
    }
}
