using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Controllers.Urls;

namespace NEBULOUS.Controllers.Routs
{
    [Route("api/[controller]")]
    [ApiController]
    public class Post : ControllerBase
    {
        // auth-session
        [HttpGet(Urls.Urls.AuthSession)]
        public IActionResult authSession()
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
                return Ok("Ruta Auth-Session");
            }
        }
       
        // logout
        [HttpGet(Urls.Urls.Logout)]
        public IActionResult logOut()
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
                return Ok("Ruta Log-Out");
            }
        }
    }
}
