using System;

namespace DecoratorValidation.DateValidation
{
    public abstract class DateValidator
    {
        public const String ErrorMessageDelimiter = @"/";

        public abstract bool Validate(DateTime toValidate, ref String errorMessage);
    }
}