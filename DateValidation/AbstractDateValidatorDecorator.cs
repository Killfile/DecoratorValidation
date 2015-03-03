using System;

namespace DecoratorValidation.DateValidation
{
    public abstract class AbstractDateValidatorDecorator : AbstractDateValidator
    {
        protected AbstractDateValidator argument;

        protected AbstractDateValidatorDecorator(AbstractDateValidator a)
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