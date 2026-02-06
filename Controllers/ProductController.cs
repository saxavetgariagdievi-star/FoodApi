using FoodApi.DTOs.Romas;
using FoodApi.Interfaces.Services;
using FoodApi.Response.Extion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var product = await _productService.GetAllAsync();
                return Ok(ApiResponseExtions.Succsess(product));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server Error Occurred"));
            }
        }

        [HttpGet("ProductName/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                if (product == null) 
                    return NotFound(ApiResponseExtions.Fail("Menu Not Found"));

                return Ok(ApiResponseExtions.Succsess(product));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server Error Occurred"));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtions.Fail("Validation Error"));

                var create = await _productService.CreateAsync(dto);
                return Ok(ApiResponseExtions.Succsess(create, "Product Created"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server Error Occurred"));
            }
        }

        [HttpPut("Product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtions.Fail("Validation Error"));

                var update = await _productService.UpdateAsync(id, dto);
                if (update == null)
                    return NotFound(ApiResponseExtions.Fail("Product Not Found"));

                return Ok(ApiResponseExtions.Succsess(update, "Product Updated"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server Error Occurred"));
            }
        }

        [HttpDelete("Product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var deleted = await _productService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(ApiResponseExtions.Fail("Product not found or cannot be deleted"));

                return Ok(ApiResponseExtions.Succsess(null, "Product deleted"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server error occurred"));
            }
        }    
    }
}

