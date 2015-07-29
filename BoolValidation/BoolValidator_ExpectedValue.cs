using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.BoolValidation.Validators
{
    public class BoolValidator_ExpectedValue : ValidatorDecorator<bool>
    {
        private readonly String _errorMessage;
        private readonly bool _expected;

        /// <summary>
        /// Creates a validator for Booleger comparison
        /// </summary>
        /// <param name="a">An Booleger validator - this system uses the constructor pattern</param>
        /// <param name="expected">The value to compare against</param>
        /// <param name="errorMessage">The returned error message if validation fails</param>
        public BoolValidator_ExpectedValue(Validator<bool> a, bool expected, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _expected = expected;
        }

        public override bool Validate(object toValidateObj)
        {
            bool toValidate = Cast(toValidateObj);
            isValid =  toValidate == _expected;
            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}