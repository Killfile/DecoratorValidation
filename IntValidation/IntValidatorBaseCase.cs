using System;

namespace DecoratorValidation.IntValidation
{
    public class IntValidatorBaseCase : IntValidator
    {
        public override bool Validate(int toValidate, ref String errorMessage)
        {
            return true;
        }
    }
}