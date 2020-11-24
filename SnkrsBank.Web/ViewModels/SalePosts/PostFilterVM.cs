namespace SnkrsBank.Web.ViewModels.SalePosts
{
    public class PostFilterVM
    {
        public string OrderBy { get; set; }

        public string SneakerName { get; set; }

        public string SneakerCategory { get; set; }

        public string Brand { get; set; }

        public int Size { get; set; }

        public string Condition { get; set; }

        public string Keyword { get; set; }

        public int RatingAbove { get; set; }
    }
}