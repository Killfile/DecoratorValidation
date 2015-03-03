using System;

namespace DecoratorValidation.BoolValidation
{
    public abstract class BoolValidatorDecorator : BoolValidator
    {
        protected BoolValidator argument;

        protected BoolValidatorDecorator(BoolValidator a)
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