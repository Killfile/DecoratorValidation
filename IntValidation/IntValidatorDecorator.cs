using System;

namespace DecoratorValidation.IntValidation
{
    public abstract class IntValidatorDecorator : IntValidator
    {
        protected IntValidator argument;

        public IntValidatorDecorator(IntValidator a)
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