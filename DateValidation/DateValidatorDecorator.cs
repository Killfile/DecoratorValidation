using System;

namespace DecoratorValidation.DateValidation
{
    public abstract class DateValidatorDecorator : DateValidator
    {
        protected DateValidator argument;

        protected DateValidatorDecorator(DateValidator a)
        {
            argument = a;
        }

        public override bool Validate(DateTime toValidate, ref String errorMessage)
        {
            if (argument != null)
                return argument.Validate(toValidate, ref errorMessage);
            
            errorMessage = String.Empty;
            return true;
        }
    }
}