namespace SnkrsBank.Domain.Models
{
    using SnkrsBank.Domain.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
