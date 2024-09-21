using Microsoft.AspNetCore.Mvc;

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
