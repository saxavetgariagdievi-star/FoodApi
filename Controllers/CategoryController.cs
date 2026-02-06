using FoodApi.DTOs.Cate;
using FoodApi.Interfaces.Services;
using FoodApi.Response.Extion;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return Ok(ApiResponseExtions.Succsess(categories));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server error occurred"));
            }
        }

        [HttpGet("CategoryName/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                    return NotFound(ApiResponseExtions.Fail("Category not found"));

                return Ok(ApiResponseExtions.Succsess(category));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server error occurred"));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtions.Fail("Validation error"));

                var created = await _categoryService.CreateAsync(dto);
                return Ok(ApiResponseExtions.Succsess(created, "Category created"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server error occurred"));
            }
        }

        [HttpPut("Category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ApiResponseExtions.Fail("Validation error"));

                var updated = await _categoryService.UpdateAsync(id, dto);
                if (updated == null)
                    return NotFound(ApiResponseExtions.Fail("Category not found"));

                return Ok(ApiResponseExtions.Succsess(updated, "Category updated"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server error occurred"));
            }
        }

        [HttpDelete("Category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var deleted = await _categoryService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(ApiResponseExtions.Fail("Category not found or cannot be deleted"));

                return Ok(ApiResponseExtions.Succsess(null, "Category deleted"));
            }
            catch
            {
                return StatusCode(500, ApiResponseExtions.Fail("Server error occurred"));
            }
        }
    }
}


