using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DateValidation.Validators
{
    public class DateValidator_Before : ValidatorDecorator<DateTime>
    {
        private readonly String _errorMessage;
        private readonly DateTime _expected;

        /// <summary>
        /// Creates a validator for DateTime comparison
        /// </summary>
        /// <param name="a">A DateTime validator - this system uses the decorator pattern</param>
        /// <param name="laterBound">The value must be less than this date to validate</param>
        /// <param name="errorMessage">The returned error message if validation fails</param>
        public DateValidator_Before(Validator<DateTime> a, DateTime laterBound, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _expected = laterBound;
        }

        public override bool Validate(DateTime toValidate, StringBuilder errorAccumulator)
        {
            

            isValid =  toValidate < _expected;
            AppendErrorMessage(errorAccumulator, _errorMessage);

            return isValid && base.Validate(toValidate, errorAccumulator);
        }
    }
}