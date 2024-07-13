using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Api.Repositories.Contracts;

namespace PersonalFinanceApp.Api.Controllers
{
    [Route("api/metadata")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        private readonly IMetadataRepository _categoryRepository;

        public MetadataController(IMetadataRepository transactionRepository)
        {
            _categoryRepository = transactionRepository;
        }

        #region CATEGORIES

        // GET api/categories/5
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // GET api/categories?transactionType=1
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(int? transactionType)
        {
            var categories = (transactionType != null) ? await _categoryRepository.GetCategoriesByTransactionType(transactionType.Value)
                : await _categoryRepository.GetCategories();
            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        #endregion

        #region PAYMENT METHODS

        // GET api/paymentMethods/5
        [HttpGet("paymentMethods/{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(int id)
        {
            var paymentMethod = await _categoryRepository.GetPaymentMethod(id);
            if (paymentMethod == null)
                return NotFound();

            return Ok(paymentMethod);
        }

        // GET api/paymentMethods
        [HttpGet("paymentMethods")]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        {
            var paymentMethods = await _categoryRepository.GetPaymentMethods();
            if (paymentMethods == null)
                return NotFound();

            return Ok(paymentMethods);
        }

        #endregion

        #region TRANSACTION TYPES

        // GET api/transactionTypes/1
        [HttpGet("transactionTypes/{id}")]
        public async Task<ActionResult<TransactionType>> GetTransactionType(int id)
        {
            var transactionType = await _categoryRepository.GetTransactionType(id);
            if (transactionType == null)
                return NotFound();

            return Ok(transactionType);
        }

        // GET api/transactionTypes
        [HttpGet("transactionTypes")]
        public async Task<ActionResult<IEnumerable<TransactionType>>> GetTransactionTypes()
        {
            var transactionTypes = await _categoryRepository.GetTransactionTypes();
            if (transactionTypes == null)
                return NotFound();

            return Ok(transactionTypes);
        }

        #endregion
    }
}
