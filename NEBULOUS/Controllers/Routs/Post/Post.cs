using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.User;

namespace NEBULOUS.Controllers.Routs.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class Post : ControllerBase
    {
        // auth-session
        [HttpPost(Urls.Urls.AuthSession)]
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
        [HttpPost(Urls.Urls.Logout)]
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
