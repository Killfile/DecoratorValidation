using System;

namespace DecoratorValidation.IntValidation
{
    public abstract class AbstractIntValidatorDecorator : AbstractIntValidator
    {
        protected AbstractIntValidator argument;

        public AbstractIntValidatorDecorator(AbstractIntValidator a)
        {
            argument = a;
        }

        public override bool Validate(int toValidate, ref String errorMessage)
        {
            if (argument != null)
                return argument.Validate(toValidate, ref errorMessage);
            errorMessage = String.Empty;
            return true;
        }
    }
}