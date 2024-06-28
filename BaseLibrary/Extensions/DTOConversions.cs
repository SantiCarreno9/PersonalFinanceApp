using BaseLibrary.DTOs;
using BaseLibrary.Entities;

namespace BaseLibrary.Extensions
{
    public static class DTOConversions
    {
        #region Transaction

        public static Transaction ConvertToEntity(this TransactionDTO transactionDTO)
        {
            return new Transaction
            {
                Id = transactionDTO.Id,
                Date = transactionDTO.Date,
                TotalAmount = transactionDTO.TotalAmount,
                Location = transactionDTO.Location,
                PaymentMethodId = transactionDTO.PaymentMethodId,
                TransactionTypeId = transactionDTO.TransactionTypeId,
                TransactionDetails = transactionDTO.TransactionDetails!.ConvertToEntity()
            };
        }

        public static IEnumerable<Transaction> ConvertToEntity(this IEnumerable<TransactionDTO> transactionsDTO)
        {
            foreach (var transactionDTO in transactionsDTO)
            {
                yield return transactionDTO.ConvertToEntity();
            }
        }

        public static TransactionDTO ConvertToDTO(this Transaction transaction)
        {
            return new TransactionDTO
            {
                Id = transaction.Id,
                TotalAmount = transaction.TotalAmount,
                Date = transaction.Date,
                CategoryId = transaction.CategoryId,
                Location = transaction.Location,
                TransactionTypeId = transaction.TransactionTypeId,
                PaymentMethodId = transaction.PaymentMethodId,
                TransactionDetails = transaction.TransactionDetails.ConvertToDTO()
            };
        }

        public static IEnumerable<TransactionDTO> ConvertToDTO(this IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                yield return transaction.ConvertToDTO();
            }
        }

        #endregion

        #region TransactionDetail

        public static TransactionDetail ConvertToEntity(this TransactionDetailDTO transactionDetailDTO)
        {
            return new TransactionDetail
            {                
                Amount = transactionDetailDTO.Amount,
                CategoryId = transactionDetailDTO.CategoryId,
                Description = transactionDetailDTO.Description,                
            };
        }

        public static List<TransactionDetail> ConvertToEntity(this IEnumerable<TransactionDetailDTO> transactionDetails)
        {
            var list = new List<TransactionDetail>();
            foreach (var transactionDetail in transactionDetails)
            {
                list.Add(transactionDetail.ConvertToEntity());
            }
            return list;
        }

        public static TransactionDetailDTO ConvertToDTO(this TransactionDetail transactionDetail)
        {
            return new TransactionDetailDTO
            {                
                Amount = transactionDetail.Amount,
                CategoryId = transactionDetail.CategoryId,
                Description = transactionDetail.Description
            };
        }

        public static List<TransactionDetailDTO> ConvertToDTO(this IEnumerable<TransactionDetail> transactionDetails)
        {
            var list = new List<TransactionDetailDTO>();
            if (transactionDetails != null)
                foreach (var detail in transactionDetails)                
                    list.Add(detail.ConvertToDTO());                
            return list;
        }

        #endregion
    }
}
