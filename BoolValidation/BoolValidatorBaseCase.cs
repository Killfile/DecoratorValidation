using System;

namespace DecoratorValidation.BoolValidation
{
    public class BoolValidatorBaseCase : BoolValidator
    {
        public override bool Validate(bool toValidate, ref String errorMessage)
        {
            return true;
        }
    }
}