using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DateValidation.Validators
{
    public class DateValidator_After : ValidatorDecorator<DateTime>
    {
        private readonly String _errorMessage;
        private readonly DateTime _expected;

        /// <summary>
        /// Creates a validator for DateTime comparison
        /// </summary>
        /// <param name="a">A DateTime validator - this system uses the decorator pattern</param>
        /// <param name="earlierBound">The value must be geater than this date to validate</param>
        /// <param name="errorMessage">The returned error message if validation fails</param>
        public DateValidator_After(Validator<DateTime> a, DateTime earlierBound, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _expected = earlierBound;
        }

        public override bool Validate(DateTime toValidate)
        {
            isValid =  toValidate > _expected;

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}