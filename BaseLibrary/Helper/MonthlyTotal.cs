namespace BaseLibrary.Helper
{
    public class MonthlyTotal
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalAmount { get; set; }
        public string MonthName
        {
            get
            {
                return new DateTime(Year, Month, 1).ToString("MMMM");
            }
        }

    }
}
