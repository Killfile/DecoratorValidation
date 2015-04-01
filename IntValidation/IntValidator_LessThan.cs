using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.IntValidation.Validators
{
    public class IntValidator_LessThan : ValidatorDecorator<int>
    {
        private readonly String _errorMessage;
        private readonly int CeilingValue;
        private readonly bool LessThanOrEqualTo;

        /// <summary>
        /// Creates a validator for integer comparison
        /// </summary>
        /// <param name="a">An integer validator - this system uses the constructor pattern</param>
        /// <param name="ceilingValue">The maximum value which will pass this validator </param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public IntValidator_LessThan(Validator<int> a, int ceilingValue, bool lessThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.CeilingValue = ceilingValue;
            this.LessThanOrEqualTo = lessThanOrEqualTo;
        }

        public override bool Validate(int toValidate)
        {
            

            isValid =  toValidate < CeilingValue || (LessThanOrEqualTo && toValidate == CeilingValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}