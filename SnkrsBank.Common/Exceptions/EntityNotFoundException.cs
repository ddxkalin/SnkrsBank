namespace SnkrsBank.Common.Exceptions
{
    using System;

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }
}
