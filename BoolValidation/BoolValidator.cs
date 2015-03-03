using System;

namespace DecoratorValidation.BoolValidation
{
    public class BoolValidator : AbstractBoolValidator
    {
        public override bool Validate(bool toValidate, ref String errorMessage)
        {
            return true;
        }
    }
}