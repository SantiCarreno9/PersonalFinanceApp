using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceApp.Web.Models
{
    public class DateRange
    {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
