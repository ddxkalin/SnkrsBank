namespace SnkrsBank.Web.ViewModels
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SneakerEventResult
    {
        [JsonProperty("results")]
        public List<SneakerEvent> Results { get; set; }
    }
}