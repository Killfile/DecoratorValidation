﻿using DecoratorValidation.Core;
using System;
using System.Text;

namespace DecoratorValidation.DoubleValidation.Validators
{
    public class DoubleValidator_LessThan : ValidatorDecorator<double>
    {
        private readonly String _errorMessage;
        private readonly double CeilingValue;
        private readonly bool LessThanOrEqualTo;

        /// <summary>
        /// Creates a validator for doubleeger comparison
        /// </summary>
        /// <param name="a">An doubleeger validator - this system uses the constructor pattern</param>
        /// <param name="ceilingValue">The maximum value which will pass this validator </param>
        /// <param name="greaterThanOrEqualTo">Set this to true if the comparison should be inclusive of the floor value</param>
        /// <param name="ErrorMessage">The error message that will be generated if validation fails</param>
        public DoubleValidator_LessThan(Validator<double> a, double ceilingValue, bool lessThanOrEqualTo, String ErrorMessage)
            : base(a)
        {
            _errorMessage = ErrorMessage;
            this.CeilingValue = ceilingValue;
            this.LessThanOrEqualTo = lessThanOrEqualTo;
        }

        public override bool Validate(object toValidateObj)
        {
            double toValidate = Convert.ToDouble(toValidateObj);
            isValid =  toValidate < CeilingValue || (LessThanOrEqualTo && toValidate == CeilingValue);

            AppendErrorMessage(_errorMessage);

            return isValid && base.Validate(toValidate);
        }
    }
}