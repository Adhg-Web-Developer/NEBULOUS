using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.User;

namespace NEBULOUS.Controllers.Routs.Post.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        // Users
        // Crear
        [HttpPost(Urls.Urls.Users + "/methods/create/")]
        public async Task<ActionResult> createUser([FromForm, Bind(Prefix = "")] Models.User.User user, [FromServices] string connection_sql)
        {
            bool res = await Task.FromResult(new LUser(connection_sql).CreateUser(user));

            if (user == null && !res)
            {
                return StatusCode(500, "Error al crear el usuario.");
            }

            return Ok(res);
        }

        // Modificar
        [HttpPost(Urls.Urls.Users + "/methods/modify/")]
        public async Task<ActionResult> modifyUser([FromForm, Bind(Prefix = "")] Models.User.User user, [FromServices] string connection_sql)
        {
            bool res = await Task.FromResult(new LUser(connection_sql).ModifyUser(user));

            if (user == null && !res)
            {
                return StatusCode(500, "Error al crear el usuario.");
            }

            return Ok(res);
        }

        // Eliminar
        [HttpPost(Urls.Urls.Users + "/methods/delete/")]
        public async Task<ActionResult> deleteUser([FromForm] int id, [FromServices] string connection_sql)
        {
            bool res = await Task.FromResult(new LUser(connection_sql).DeleteUser(id));

            if (res == false && !res)
            {
                return StatusCode(500, "Error al crear el usuario.");
            }

            return Ok(res);
        }
    }
}