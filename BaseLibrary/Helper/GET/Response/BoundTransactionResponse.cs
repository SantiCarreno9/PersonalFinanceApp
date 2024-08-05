using BaseLibrary.DTOs;

namespace BaseLibrary.Helper.GET.Response
{
    public class BoundTransactionResponse : GetBoundTransaction
    {        
        public TransactionDTO Transaction { get; set; }
    }
}
