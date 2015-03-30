using DecoratorValidation.Core;
using System;

namespace DecoratorValidation.StringValidation
{
    public class StringValidatorBaseCase : Validator<String>
    {
        public override bool Validate(String toValidate, ref string errorMessage)
        {
            return true;
        }
    }
}