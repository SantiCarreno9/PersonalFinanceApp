using BaseLibrary.DTOs;
using BaseLibrary.Extensions;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Api.Repositories.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceApp.Api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        // GET: api/transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactions()
        {
            var transactions = await _transactionRepository.GetTransactions();

            if (transactions == null)
                return NoContent();

            var transactionsDTOs = transactions.ConvertToDTO();
            return Ok(transactionsDTOs);
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetTransaction(long id)
        {
            var transaction = await _transactionRepository.GetTransaction(id);
            if (transaction == null)
                return NotFound();

            var transactionDTO = transaction.ConvertToDTO();
            return Ok(transactionDTO);
        }        

        // POST api/transactions
        [HttpPost]
        public async Task<ActionResult<TransactionDTO>> CreateTransaction([FromBody] TransactionDTO transactionToAdd)
        {
            if (transactionToAdd == null)
                throw new BadHttpRequestException(new ArgumentNullException().Message);
            var transaction = await _transactionRepository.AddTransaction(transactionToAdd.ConvertToEntity());
            return CreatedAtAction(
                nameof(GetTransaction),
                new { id = transaction.Id },
                transaction.ConvertToDTO());
        }

        // PUT api/transactions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TransactionDTO>> UpdateTransaction(long id, [FromBody] TransactionDTO transactionToUpdate)
        {
            if (transactionToUpdate == null)
                throw new BadHttpRequestException(new ArgumentNullException().Message);
            if (id != transactionToUpdate.Id)            
                return BadRequest();

            var transaction = await _transactionRepository.UpdateTransaction(id, transactionToUpdate.ConvertToEntity());
            if (transaction == null)            
                return NotFound();            
            
            return Ok(transaction.ConvertToDTO());
        }

        // DELETE api/transactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(long id)
        {
            var transaction = await _transactionRepository.DeleteTransaction(id);
            if(transaction==null)
                return NotFound();
            return NoContent();
        }
    }
}
