using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.User;
using NEBULOUS.Models.User;

namespace NEBULOUS.Controllers.Routs
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

        // Users
        // Crear
        [HttpPost(Urls.Urls.Users + "/methods/create/")]
        public async Task<ActionResult> createUser([FromForm] User user, [FromServices] string connection_sql)
        {
            bool res = await Task.FromResult(new LUser(connection_sql).CreateUser(user));

            if (user == null && !res)
            {
                return StatusCode(500, "Error al crear el usuario.");
            }
            
            return Ok(res);
        }
        // Editar
        // Eliminar
        // Eliminar
    }
}
