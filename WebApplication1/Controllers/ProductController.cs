using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/v{version:apiVersion}/product")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {
        IProductService _prdSrv;
        public ProductController(IProductService prdSrv)
        {
            _prdSrv = prdSrv;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_prdSrv.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest();
            else
            {
                Product prd = _prdSrv.GetProductById(id);
                if (prd != null)
                    return Ok(prd);
                else
                    return NotFound("Product not found");
            }
        }

        [HttpPost()]
        public IActionResult Post(Product currPrd)
        {
            if (_prdSrv.SaveProduct(currPrd))
                return Ok("Saved successfully");
            else
                return StatusCode(StatusCodes.Status400BadRequest);
        }

        public IActionResult Put(int id, Product currPrd)
        {
            if (_prdSrv.UpdateProduct(id, currPrd))
                return Ok("Updated successfully");
            else
                return StatusCode(StatusCodes.Status400BadRequest);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest("Invalid request");
            else
            {
                if (_prdSrv.DeleteProduct(id))
                {
                    return Ok("Removed successfully");
                }
                else
                {
                    return NotFound("Product not found");
                }
            }
        }
    }
}