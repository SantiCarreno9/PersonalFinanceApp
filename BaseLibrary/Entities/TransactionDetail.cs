namespace BaseLibrary.Entities
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }        
        public decimal Amount { get; set; }

        public Transaction Transaction { get; set; }
        public Category Category { get; set; }
    }
}
