using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.Operation.Operation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Post.Operation.Operation
{
    [Route("api/[controller]")]
    [ApiController]
    public class Operation : ControllerBase
    {
        // Operation
        // Crear
        [HttpPost(Urls.Urls.Operations + "/methods/create/")]
        public async Task<ActionResult> createOperation([FromForm, Bind(Prefix = "")] Models.Operation.Operation.Operation operation, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                bool res = await Task.FromResult(new LOperation(connection_sql).CreateOperation(operation));

                if (operation == null && !res)
                {
                    return StatusCode(500, "Error al crear el registro.");
                }

                return Ok(res);
            }
            else
            {
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }

        // Modificar
        [HttpPost(Urls.Urls.ProductCategory + "/methods/modify/")]
        public async Task<ActionResult> modifyOperation([FromForm, Bind(Prefix = "")] Models.Operation.Operation.Operation operation, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LOperation(connection_sql).ModifyOperation(operation));

                    if (operation == null && !res)
                    {
                        return StatusCode(500, "Error al modificar el registro.");
                    }

                    return Ok(res);
                }
                else
                {
                    return Ok("No es posible realizar esta acción debido a que no cuentas con los permisos necesarios.");
                }
            }
            else
            {
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }

        // Eliminar
        [HttpPost(Urls.Urls.ProductCategory + "/methods/delete/")]
        public async Task<ActionResult> deleteOperation([FromForm] int id, [FromServices] string connection_sql)
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                if (HttpContext.Session.GetString("idUserType") == "1")
                {
                    bool res = await Task.FromResult(new LOperation(connection_sql).DeleteOperation(id));

                    if (res == false && !res)
                    {
                        return StatusCode(500, "Error al eliminar el registro.");
                    }

                    return Ok(res);
                }
                else
                {
                    return Ok("No es posible realizar esta acción debido a que no cuentas con los permisos necesarios.");
                }
            }
            else
            {
                return Ok("No es posible acceder a esta ruta, primeramente necesitas iniciar sesión.");
            }
        }
    }
}
