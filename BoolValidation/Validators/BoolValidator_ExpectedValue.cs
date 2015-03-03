using System;

namespace DecoratorValidation.BoolValidation.Validators
{
    public class BoolValidator_ExpectedValue : BoolValidatorDecorator
    {
        private readonly String _errorMessage;
        private readonly bool _expected;

        /// <summary>
        /// Creates a validator for Booleger comparison
        /// </summary>
        /// <param name="a">An Booleger validator - this system uses the constructor pattern</param>
        /// <param name="expected">The value to compare against</param>
        /// <param name="errorMessage">The returned error message if validation fails</param>
        public BoolValidator_ExpectedValue(BoolValidator a, bool expected, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _expected = expected;
        }

        public override bool Validate(bool toValidate, ref String errorMessage)
        {
            if (errorMessage == null)
                errorMessage = String.Empty;

            bool validates = toValidate == _expected;

            if (validates == false)
                errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}