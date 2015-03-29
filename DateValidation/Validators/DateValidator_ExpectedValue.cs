using System;

namespace DecoratorValidation.DateValidation.Validators
{
    public class DateValidator_ExpectedValue : DateValidatorDecorator
    {
        private readonly String _errorMessage;
        private readonly DateTime _expected;

        /// <summary>
        /// Creates a validator for Booleger comparison
        /// </summary>
        /// <param name="a">An Booleger validator - this system uses the constructor pattern</param>
        /// <param name="expected">The value to compare against</param>
        /// <param name="errorMessage">The returned error message if validation fails</param>
        public DateValidator_ExpectedValue(DateValidator a, DateTime expected, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _expected = expected;
        }

        public override bool Validate(DateTime toValidate, ref String errorMessage)
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