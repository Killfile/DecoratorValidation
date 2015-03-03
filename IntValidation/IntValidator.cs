using System;

namespace DecoratorValidation.IntValidation
{
    public class IntValidator : AbstractIntValidator
    {
        public override bool Validate(int toValidate, ref String errorMessage)
        {
            return true;
        }
    }
}