using System;

namespace DecoratorValidation.IntValidation.Validators
{
    public class IntValidator_LessThan : AbstractIntValidatorDecorator
    {
        private readonly String ErrorMessage;
        private readonly int CeilingValue;
        private readonly bool LessThanOrEqualTo;

        /// <summary>
        /// Creates a validator for integer comparison
        /// </summary>
        /// <param name="a">An integer validator - this system uses the constructor pattern</param>
        /// <param name="ceilingValue">The maximum value which will pass this validator </param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public IntValidator_LessThan(AbstractIntValidator a, int ceilingValue, bool lessThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            this.ErrorMessage = ErrorMessage;
            this.CeilingValue = ceilingValue;
            this.LessThanOrEqualTo = lessThanOrEqualTo;
        }

        public override bool Validate(int toValidate, ref String errorMessage)
        {
            if (errorMessage == null)
                errorMessage = String.Empty;

            bool validates = toValidate < CeilingValue || (LessThanOrEqualTo && toValidate == CeilingValue);

            if (validates == false)
                errorMessage += (errorMessage.Length > 0 ? ErrorMessageDelimiter : "") + ErrorMessage;

            return validates && base.Validate(toValidate, ref errorMessage);
        }
    }
}