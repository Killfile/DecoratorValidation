using System;

namespace DecoratorValidation.DateValidation
{
    public class DateValidatorBaseCase : DateValidator
    {
        public override bool Validate(DateTime toValidate, ref String errorMessage)
        {
            return true;
        }
    }
}