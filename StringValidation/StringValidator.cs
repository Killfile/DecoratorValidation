using System;

namespace DecoratorValidation.StringValidation
{
    public abstract class StringValidator
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(String toValidate, ref string errorMessage);
    }
}