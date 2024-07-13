namespace BaseLibrary.Helper.GET.Response
{
    public class SummaryByPropertyResponse : GetSummaryByProperty
    {
        public IEnumerable<Summary>? Summaries { get; set; }
    }
}
