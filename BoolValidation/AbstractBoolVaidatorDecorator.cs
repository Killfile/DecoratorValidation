using System;

namespace DecoratorValidation.BoolValidation
{
    public abstract class AbstractBoolValidatorDecorator : AbstractBoolValidator
    {
        protected AbstractBoolValidator argument;

        protected AbstractBoolValidatorDecorator(AbstractBoolValidator a)
        {
            argument = a;
        }

        public override bool Validate(bool toValidate, ref String errorMessage)
        {
            if (argument != null)
                return argument.Validate(toValidate, ref errorMessage);
            
            errorMessage = String.Empty;
            return true;
        }
    }
}