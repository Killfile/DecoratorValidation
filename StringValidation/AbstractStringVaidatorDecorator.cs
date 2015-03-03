using System;

namespace DecoratorValidation.StringValidation
{
    public abstract class StringValidatorDecorator : StringValidator
    {
        protected StringValidator argument;

        protected StringValidatorDecorator(StringValidator a)
        {
            argument = a;
        }

        public override bool Validate(String toValidate, ref string errorMessage)
        {
            if (argument != null)
                return argument.Validate(toValidate, ref errorMessage);
            
            errorMessage = string.Empty;
            return true;
        }
    }
}