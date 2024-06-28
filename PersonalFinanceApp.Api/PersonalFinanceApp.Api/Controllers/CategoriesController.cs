using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Api.Repositories.Contracts;

namespace PersonalFinanceApp.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository transactionRepository)
        {
            _categoryRepository = transactionRepository;
        }        

        // GET api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // GET api/categories?transactionType=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories([FromQuery] int? transactionType)
        {
            var categories = (transactionType != null) ? await _categoryRepository.GetCategoriesByTransactionType(transactionType.Value)
                : await _categoryRepository.GetCategories();
            if (categories == null)
                return NotFound();

            return Ok(categories);
        }
    }
}
