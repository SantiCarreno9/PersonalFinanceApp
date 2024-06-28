using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Api.Repositories.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinanceApp.Api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        #region api/transactions

        // GET: api/transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactions()
        {
            var transactions = await _transactionRepository.GetTransactions(User.GetUserId());

            if (transactions == null)
                return NoContent();

            var transactionsDTOs = transactions.ConvertToDTO();
            return Ok(transactionsDTOs);
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetTransaction(long id)
        {
            var transaction = await _transactionRepository.GetTransaction(User.GetUserId(), id);
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
            var transactionEntity = transactionToAdd.ConvertToEntity();
            transactionEntity.UserId = User.GetUserId();
            transactionEntity.Update();
            var transaction = await _transactionRepository.AddTransaction(transactionEntity);
            return CreatedAtAction(
                nameof(GetTransaction),
                new { id = transaction.Id },
                transaction.ConvertToDTO());
        }

        // PUT api/transactions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TransactionDTO>> UpdateTransaction(long id, [FromBody] TransactionDTO transaction)
        {
            if (transaction == null)
                throw new BadHttpRequestException(new ArgumentNullException().Message);            

            if (id != transaction.Id)
                return BadRequest();

            bool ownsTransaction = await _transactionRepository.UserOwnsTransaction(User.GetUserId(), id);

            if (!ownsTransaction)
                return BadRequest();

            var transactionEntity = transaction.ConvertToEntity();
            transactionEntity.UserId = User.GetUserId();
            transactionEntity.Update();
            var transactionF = await _transactionRepository.UpdateTransaction(id, transactionEntity);
            if (transactionF == null)
                return NotFound();

            return Ok(transactionF.ConvertToDTO());
        }

        // DELETE api/transactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(long id)
        {
            bool ownsTransaction = await _transactionRepository.UserOwnsTransaction(User.GetUserId(), id);

            if (!ownsTransaction)
                return BadRequest();

            var transaction = await _transactionRepository.DeleteTransaction(id);
            if (transaction == null)
                return NotFound();
            return NoContent();
        }

        #endregion

        #region api/transactions/[misc]


        // GET: api/transactions
        [AllowAnonymous]
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TransactionType>>> GetTransactionTypes()
        {
            var types = await _transactionRepository.GetTransactionTypes();

            if (types == null)
                return NoContent();
            
            return Ok(types);
        }       

        #endregion
    }
}
