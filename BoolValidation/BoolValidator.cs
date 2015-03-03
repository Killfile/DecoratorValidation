using System;

namespace DecoratorValidation.BoolValidation
{
    public abstract class BoolValidator
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(bool toValidate, ref String errorMessage);
    }
}