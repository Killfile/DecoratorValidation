using System;

namespace DecoratorValidation.DateValidation
{
    public abstract class AbstractDateValidator
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(DateTime toValidate, ref String errorMessage);
    }
}