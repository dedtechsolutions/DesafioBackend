using System;

namespace DesafioBack.Domain.Validations
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        {
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidation(error);
        }

        public static void ErrorId(string error)
        {
            throw new DomainExceptionValidation(error);
        }
    }
}
