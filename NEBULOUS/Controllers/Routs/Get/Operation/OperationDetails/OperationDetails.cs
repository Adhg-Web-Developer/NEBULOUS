using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NEBULOUS.Controllers.Routs.Get.Operation.OperationDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationDetails : ControllerBase
    {
        // OperationDetails
        [HttpGet(Urls.Urls.Operations+"/operation-details")]
        public IActionResult operationDetails()
        {
            if (HttpContext.Session.GetString("loggedIn") == "true")
            {
                return Ok("Estás en la ruta de Detalles de Operación.");
            }
            else
            {
                return Ok("No es posible acceder a esta ruta debido a que no has iniciado sesión.");
            }
        }
    }
}
