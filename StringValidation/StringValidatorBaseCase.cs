using System;

namespace DecoratorValidation.StringValidation
{
    public class StringValidatorBaseCase : StringValidator
    {
        public override bool Validate(String toValidate, ref string errorMessage)
        {
            return true;
        }
    }
}