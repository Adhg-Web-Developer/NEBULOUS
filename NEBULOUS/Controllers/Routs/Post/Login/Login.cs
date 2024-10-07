using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.Login;

namespace NEBULOUS.Controllers.Routs.Post.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        // autenticar la sesión
        [HttpPost(Urls.Urls.AuthSession)]
        public async Task<ActionResult> authSession([FromForm, Bind(Prefix = "")] Models.User.User session, [FromServices] string connection_sql)
        {
            HttpContext.Session.SetString("id", "");
            HttpContext.Session.SetString("idUserType", "");
            HttpContext.Session.SetString("loggedIn", "false");

            if (HttpContext.Session.GetString("loggedIn") == "false")
            {
                var UserSession = await Task.FromResult(new LLogin(connection_sql).authSession(session));

                if (session == null)
                {
                    return StatusCode(500, "Error al crear el usuario.");
                }

                // Sesión del usuario
                if (UserSession != null && UserSession.GetType().GetProperty("id").GetValue(UserSession, null).ToString() != "False")
                {
                    HttpContext.Session.SetString("id", UserSession.GetType().GetProperty("id").GetValue(UserSession, null).ToString());
                    HttpContext.Session.SetString("idUserType", UserSession.GetType().GetProperty("idUserType").GetValue(UserSession, null).ToString());
                    HttpContext.Session.SetString("loggedIn", "true");
                }

                return Ok(UserSession);
            }
            else
            {
                HttpContext.Session.SetString("id", "");
                HttpContext.Session.SetString("loggedIn", "false");
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }
        // cerrar sesión
        [HttpPost(Urls.Urls.Logout)]
        public async Task<ActionResult> logOut([FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "false")
            {
                return Ok("No es posible acceder a esta ruta por el momento, por favor, inicia sesión primeramente.");
            }
            else
            {
                var res = await Task.FromResult(new LLogin(connection_sql).logOut(HttpContext.Session.GetString("id")));

                // Sesión del usuario
                HttpContext.Session.Clear();
                HttpContext.Response.Cookies.Delete(".AspNetCore.Session");

                return Ok("Sesión cerrada correctamente.");
            }
        }
    }
}
