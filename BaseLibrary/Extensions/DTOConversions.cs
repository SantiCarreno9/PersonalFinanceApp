using BaseLibrary.DTOs;
using BaseLibrary.Entities;

namespace BaseLibrary.Extensions
{
    public static class DTOConversions
    {
        public static Transaction ConvertToEntity(this TransactionDTO transactionDTO)
        {
            return new Transaction
            {
                CategoryId = transactionDTO.CategoryId,
                Date = transactionDTO.Date,
                Amount = transactionDTO.Amount,
                Description = transactionDTO.Description,
                Location = transactionDTO.Location,
                TransactionType = transactionDTO.TransactionType
            };
        }

        public static TransactionDTO ConvertToDTO(this Transaction transaction)
        {
            return new TransactionDTO
            {
                Id = transaction.Id,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category?.Name,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                Location = transaction.Location,
                TransactionType = transaction.TransactionType
            };
        }

        public static IEnumerable<TransactionDTO> ConvertToDTO(this IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                yield return transaction.ConvertToDTO();
            }
        }
    }
}
