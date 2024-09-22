using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.User;
using System.Data.SqlClient;

namespace NEBULOUS.Controllers.Routs.Get.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        // users
        [HttpGet(Urls.Urls.Users)]
        public IActionResult users()
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
                return Ok("Ruta Users");
            }
        }

        // Obtener todos los usuarios
        [HttpGet(Urls.Urls.Users + "/methods/read/")]
        public async Task<ActionResult> readUsers([FromServices] string connection_sql)
        {
            var Users = await Task.FromResult(new LUser(connection_sql).Users());

            if (Users == null)
            {
                return StatusCode(500, "Error al leer los usuario.");
            }

            return Ok(Users);
        }

        // Obtener un solo usuario
    }
}