using System;

namespace DecoratorValidation.BoolValidation
{
    public abstract class AbstractBoolValidator
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(bool toValidate, ref String errorMessage);
    }
}