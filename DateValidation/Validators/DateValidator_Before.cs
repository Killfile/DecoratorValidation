using System;

namespace DecoratorValidation.DateValidation.Validators
{
    public class DateValidator_Before : DateValidatorDecorator
    {
        private readonly String _errorMessage;
        private readonly DateTime _expected;

        /// <summary>
        /// Creates a validator for DateTime comparison
        /// </summary>
        /// <param name="a">A DateTime validator - this system uses the decorator pattern</param>
        /// <param name="laterBound">The value must be less than this date to validate</param>
        /// <param name="errorMessage">The returned error message if validation fails</param>
        public DateValidator_Before(DateValidator a, DateTime laterBound, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _expected = laterBound;
        }

        public override bool Validate(DateTime toValidate, ref String errorMessage)
        {
            if (errorMessage == null)
                errorMessage = String.Empty;

            bool validates = toValidate < _expected;

            if (validates == false)
                errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + _errorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}