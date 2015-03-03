using System;

namespace DecoratorValidation.IntValidation
{
    public abstract class AbstractIntValidator
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(int toValidate, ref String errorMessage);
    }
}