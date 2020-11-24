namespace SnkrsBank.Web.ViewModels.SalePosts
{
    using System;

    public class PostVM
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public SneakerVM Sneaker { get; set; }

        public DateTime CreatedOn { get; set; }

        public UserVM User { get; set; }
    }
}
