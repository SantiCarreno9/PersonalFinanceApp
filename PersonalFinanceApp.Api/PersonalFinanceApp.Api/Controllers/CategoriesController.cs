using BaseLibrary.DTOs;
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
        // GET: api/transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();

            if (categories == null)
                return NoContent();
            
            return Ok(categories);
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();
            
            return Ok(category);
        }

        // POST api/transactions
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category categoryToAdd)
        {
            if (categoryToAdd == null)
                throw new BadHttpRequestException(new ArgumentNullException().Message);
            var category = await _categoryRepository.AddCategory(categoryToAdd);
            return CreatedAtAction(
                nameof(GetCategory),
                new { id = category.Id },
                category);
        }

        // PUT api/transactions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TransactionDTO>> UpdateCategory(int id, [FromBody] Category categoryToUpdate)
        {
            if (categoryToUpdate == null)
                throw new BadHttpRequestException(new ArgumentNullException().Message);
            if (id != categoryToUpdate.Id)
                return BadRequest();

            var category = await _categoryRepository.UpdateCategory(id, categoryToUpdate);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // DELETE api/transactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.DeleteCategory(id);
            if (category == null)
                return NotFound();
            return NoContent();
        }
    }
}
