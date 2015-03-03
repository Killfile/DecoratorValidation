using System;

namespace DecoratorValidation.IntValidation
{
    public abstract class IntValidator
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(int toValidate, ref String errorMessage);
    }
}