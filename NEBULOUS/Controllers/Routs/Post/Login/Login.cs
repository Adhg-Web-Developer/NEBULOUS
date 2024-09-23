using Microsoft.AspNetCore.Mvc;

namespace NEBULOUS.Controllers.Routs.Post.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        // login
        [HttpPost(Urls.Urls.AuthSession)]
        public IActionResult authSession()
        {
            return Ok();
        }
    }
}
