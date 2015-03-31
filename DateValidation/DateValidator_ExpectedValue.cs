using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DateValidation.Validators
{
    public class DateValidator_ExpectedValue : ValidatorDecorator<DateTime>
    {
        private readonly String _errorMessage;
        private readonly DateTime _expected;

        /// <summary>
        /// Creates a validator for Booleger comparison
        /// </summary>
        /// <param name="a">An Booleger validator - this system uses the constructor pattern</param>
        /// <param name="expected">The value to compare against</param>
        /// <param name="errorMessage">The returned error message if validation fails</param>
        public DateValidator_ExpectedValue(Validator<DateTime> a, DateTime expected, String errorMessage)
            : base(a)
        {
            _errorMessage = errorMessage;
            _expected = expected;
        }

        public override bool Validate(DateTime toValidate, StringBuilder errorAccumulator)
        {
         

            isValid =  toValidate == _expected;

            AppendErrorMessage(errorAccumulator, _errorMessage);

            return isValid && base.Validate(toValidate, errorAccumulator);
        }
    }
}