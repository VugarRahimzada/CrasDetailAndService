namespace EntityLayer.RapidApi
{
    public class VINResult
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<Result> Results { get; set; }
    }
}
