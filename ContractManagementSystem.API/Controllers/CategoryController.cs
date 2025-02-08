using ContractManagementSystem.BL.BusinessLogicServices;
using ContractManagementSystem.BL.BusinessLogicServices.Interfaces;
using ContractManagementSystem.DAL.DTOs.Category;
using ContractManagementSystem.DAL.DTOs.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ContractManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> GetAll()
        {
            var contractDtos = _categoryService.GetAllCategories();
            return contractDtos;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contractDtos = _categoryService.GetCategoryById(id);
            if (contractDtos == null)
                return NotFound("Not Found");

            return Ok(contractDtos);
        }

        [HttpPost]
        public async Task<UpsertCategoryDto> Add([FromBody] UpsertCategoryDto createDto)
        {
            try
            {
                _categoryService.AddCategory(createDto);
                return createDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpsertCategoryDto createDto)
        {
            try
            {
                _categoryService.UpdateCategory(id, createDto);
                return await GetById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                // (ustawiamy IsDeleted na true)
                _categoryService.DeleteCategory(id);

                // Zwracamy 200 OK
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                // Zwracamy 500 Internal Server Error z komunikatem błędu
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
