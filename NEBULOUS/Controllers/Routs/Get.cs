using Microsoft.AspNetCore.Mvc;
using NEBULOUS.Logic.User;
using NEBULOUS.Models.User;
using System.Data.SqlClient;

namespace NEBULOUS.Controllers.Routs
{
    [Route("api/[controller]")]
    [ApiController]
    public class Get : ControllerBase
    {
        // root
        [HttpGet(Urls.Urls.Root)]
        public IActionResult root()
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
                return Ok("Ruta Root");
            }
        }

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

        // dashboard
        [HttpGet(Urls.Urls.Dashboard)]
        public IActionResult dashboard()
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
                return Ok("Ruta Dashboard");
            }
        }

        // users
        private readonly List<object> Users = new List<object>();
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
            SqlDataReader reader = await Task.FromResult(new LUser(connection_sql).Users());

            if (reader == null && !reader.HasRows)
            {
                return StatusCode(500, "Error al leer los usuario.");
            }

            while (reader.Read()) {
                Users.Add(new {
                    id = (int)reader["id"],
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    state = reader["state"].ToString(),
                    user_ = reader["user_"].ToString(),
                    password_ = reader["password_"].ToString(),
                    date = reader["date"].ToString(),
                });
            }
            reader.Close();

            return Ok(Users);
        }
        // Obtener un solo usuario

        // suppliers
        [HttpGet(Urls.Urls.Suppliers)]
        public IActionResult suppliers()
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
                return Ok("Ruta Suppliers");
            }
        }

        // products
        [HttpGet(Urls.Urls.Products)]
        public IActionResult products()
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
                return Ok("Ruta Products");
            }
        }

        // product category
        [HttpGet(Urls.Urls.ProductCategory)]
        public IActionResult productCategory()
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
                return Ok("Ruta Product-Category");
            }
        }

        // product sub-category
        [HttpGet(Urls.Urls.ProductSubCategory)]
        public IActionResult productSubCategory()
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
                return Ok("Ruta Product-Sub-Category");
            }
        }

        // product brands
        [HttpGet(Urls.Urls.ProductBrands)]
        public IActionResult productBrands()
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
                return Ok("Ruta Product-Brands");
            }
        }

        // inventory
        [HttpGet(Urls.Urls.Inventory)]
        public IActionResult inventory()
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
                return Ok("Ruta Inventory");
            }
        }

        // general balance
        [HttpGet(Urls.Urls.GeneralBalance)]
        public IActionResult generalBalance()
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
                return Ok("Ruta General-Balance");
            }
        }

        // operations product buys
        [HttpGet(Urls.Urls.Operations.Buys)]
        public IActionResult productBuys()
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
                return Ok("Ruta Product-Buys");
            }
        }

        // operations product sale
        [HttpGet(Urls.Urls.Operations.Sale)]
        public IActionResult productSale()
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
                return Ok("Ruta Product-Sale");
            }
        }

    }
}
