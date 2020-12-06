namespace SnkrsBank.Web.ViewModels
{ 
    using Newtonsoft.Json;

    public class SneakerEvent
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Start { get; set; }

        public string End { get; set; }
    }
}