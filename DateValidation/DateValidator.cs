using System;

namespace DecoratorValidation.DateValidation
{
    public class DateValidator : AbstractDateValidator
    {
        public override bool Validate(DateTime toValidate, ref String errorMessage)
        {
            return true;
        }
    }
}