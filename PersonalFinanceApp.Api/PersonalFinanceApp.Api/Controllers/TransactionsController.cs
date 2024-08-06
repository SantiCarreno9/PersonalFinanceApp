using BaseLibrary.DTOs;
using BaseLibrary.Extensions;
using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;
using BaseLibrary.Helper.GET.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Api.Repositories.Contracts;

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
        public async Task<ActionResult<PagedList<TransactionDTO>>> GetTransactions([FromQuery] GetTransactionsRequestHelper request)
        {
            var transactions = await _transactionRepository.GetTransactions(User.GetUserId(), request);

            if (transactions == null)
                return NoContent();

            var response = new PagedList<TransactionDTO>(
                transactions.Items.ConvertToDTO().ToList(),
                transactions.Page,
                transactions.PageSize,
                transactions.TotalCount);

            return Ok(response);
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
                return BadRequest();

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
        [HttpDelete()]
        public async Task<ActionResult> DeleteTransaction([FromQuery] long[] id)
        {
            bool couldDelete = await _transactionRepository.DeleteTransactions(User.GetUserId(), id);
            if (!couldDelete)
                return BadRequest();
            return NoContent();
        }

        #endregion

        #region api/transactions/[misc]


        // GET: api/transactions/locations
        [HttpGet("locations")]
        public async Task<ActionResult<IEnumerable<string>>> GetExistingLocations()
        {
            var locations = await _transactionRepository.GetLocations(User.GetUserId());

            if (locations == null)
                return NoContent();

            return Ok(locations);
        }

        // GET api/transactions/total?property=transactiontype&id=1&startdate=...&enddate=...
        [HttpGet("total")]
        public async Task<ActionResult<decimal>> GetTotal([FromQuery] TransactionsFiltersDTO request)
        {
            var amount = await _transactionRepository.GetTotalAmount(User.GetUserId(), request);

            if (amount == null)
                return NoContent();

            return Ok(amount);
        }

        [HttpGet("balance")]
        public async Task<ActionResult<decimal>> GetBalance([FromQuery] TransactionsFiltersDTO request)
        {
            var amount = await _transactionRepository.GetBalance(User.GetUserId(), request);

            if (amount == null)
                return NoContent();

            return Ok(amount);
        }

        // GET api/transactions/summary?transactiontypeid=1&property=categories&&startdate=...&enddate=...
        [HttpGet("summary")]
        public async Task<ActionResult<PagedList<Summary>>> GetSummaryByProperty([FromQuery] GetSummaryByProperty request)
        {
            var summary = await _transactionRepository.GetSummaryByProperty(User.GetUserId(), request);

            if (summary == null)
                return NoContent();

            return Ok(summary);
        }

        // GET api/transactions/bound?property=date&position=first
        // GET api/transactions/bound?property=location&value=dollarama&position=first
        // GET api/transactions/bound?property=paymentmethod&id=1&position=first
        [HttpGet("bound")]
        public async Task<ActionResult<TransactionDTO>> GetBoundTransactionByProperty([FromQuery] GetBoundTransaction request)
        {
            var transaction = await _transactionRepository.GetBoundTransaction(User.GetUserId(), request);
            if (transaction == null)
                return NoContent();

            var transactionDTO = transaction.ConvertToDTO();

            return Ok(transactionDTO);
        }        

        #endregion
    }
}
